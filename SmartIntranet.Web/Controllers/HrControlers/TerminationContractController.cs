using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.PersonalContractDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.DTO.DTOs.TerminationContractDto;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Intranet;

namespace SmartIntranet.Web.Controllers
{
    public class TerminationContractController : BaseIdentityController
    {
        private readonly ITerminationContractService _contractService;
        private readonly ITerminationContractFileService _contractFileService;
        private readonly ITerminationItemService _terminationItemService;
        private readonly IContractTypeService _contractTypeService;
        private readonly IUserVacationRemainService _userVacationRemainService;
        private readonly IClauseService _clauseService;
        private readonly IAppUserService _userService;
        private readonly IWorkGraphicService _workGraphicService;
        private readonly INonWOrkingYearService _nonWorkingYearService;
        private readonly INonWorkingDayService _nonWorkingDayService;
        private readonly IVacationTypeService _vacationTypeService;
        private readonly IPersonalContractService _personalContractService;
        private readonly IPositionService _positionService;
        private readonly ICompanyService _companyService;

        public TerminationContractController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, ITerminationContractService contractService, ITerminationContractFileService contractFileService, ITerminationItemService terminationItemService, INonWOrkingYearService nonWorkingYearService, INonWorkingDayService nonWorkingDayService, IPersonalContractService personalContractService, IClauseService clauseService, IContractTypeService contractTypeService, IUserVacationRemainService userVacationRemainService, IAppUserService userService, IVacationTypeService vacationTypeService, IWorkGraphicService workGraphicService, IPositionService positionService, ICompanyService companyService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _contractService = contractService;
            _contractTypeService = contractTypeService;
            _terminationItemService = terminationItemService;
            _contractFileService = contractFileService;
            _nonWorkingYearService = nonWorkingYearService;
            _nonWorkingDayService = nonWorkingDayService;
            _personalContractService = personalContractService;
            _userVacationRemainService = userVacationRemainService;
            _userService = userService;
            _clauseService = clauseService;
            _workGraphicService = workGraphicService;
            _vacationTypeService = vacationTypeService;
            _positionService = positionService;
            _companyService = companyService;
        }


        [HttpGet]
        [Authorize(Policy = "terminationContract.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.terminationItems = await _terminationItemService.GetAllAsync(x => !x.IsDeleted);
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "terminationContract.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TerminationContractAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.IsDeleted = false;
                model.CreatedDate = DateTime.Now;
                var current = GetSignInUserId();
                var result_model = _contractService.AddReturnEntityAsync(_map.Map<TerminationContract>(model)).Result;
                var usr = await _userService.FindByUserAllInc(result_model.UserId);
                var usr2 = await _userManager.FindByIdAsync(result_model.UserId.ToString());
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());
                DateTime work_start_date = usr.StartWorkDate;
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();
                // Alqoritm for il ay gun
                TimeSpanToDateParts(DateTime.Now, work_start_date, out int years, out int months, out int days,out int hours, out int minutes);
                var work_range = (years!=0 ? years + " il " : "") + (months != 0 ? months + " ay " : "") + (days != 0 ? days + " gün" : "");
                formatKeys.Add("workRange", work_range);
                var outOfWork = "";
                var notificationWork = "0.5 misli";
                if (years>=1 && years < 5)
                {
                    outOfWork = "1.4 misli";
                    notificationWork = "0.9 misli";
                }
                else if (years >= 5 && years < 10)
                {
                    outOfWork = "1.7 misli";
                    notificationWork = "1.4 misli";
                }
                else if (years >= 10)
                {
                    outOfWork = "iki misli";
                    notificationWork = "iki misli";
                }
                formatKeys.Add("outOfWork", outOfWork);
                formatKeys.Add("notificationWork", notificationWork);

                formatKeys.Add("vacDayCount", GetRemainVacDay(model.UserId).ToString());
                formatKeys.Add("trItem", _terminationItemService.FindByIdAsync(model.TerminationItemId).Result.Name);
                formatKeys.Add("isAgree", model.IsAgree ? "bildirmişdir" : "bildirməmişdir");
                formatKeys.Add("contractBase", model.Description);
                formatKeys.Add("terminationDate", result_model.TerminationDate.ToString("dd.MM.yyyy"));
                if (result_model.ReductionDate != null)
                formatKeys.Add("reductionDate",((DateTime)result_model.ReductionDate).ToString("dd.MM.yyyy"));
                formatKeys.Add("reductionNumber", result_model.ReductionNumber);
                formatKeys.Add("commandDate", result_model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", result_model.CommandNumber);

                var doc_key = ContractFileReadyConst.termination_base;
                if (model.IsReduction)
                {
                    if (model.IsAgree)
                    {
                        doc_key = ContractFileReadyConst.termination_reduction_agree;
                    }
                    else
                    {
                        doc_key = ContractFileReadyConst.termination_reduction_not_agree;
                    }
                }
             
                usr = await _userService.FindByUserAllInc(model.UserId);
                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
               
                var file_extra = new TerminationContractFile();
                file_extra.TerminationContractId = result_model.Id;
                file_extra.IsDeleted = false;

                var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == doc_key && !x.IsDeleted))[0];
                file_extra.ClauseId = clause_result_extra.Id;
                StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                await _contractFileService.AddAsync(file_extra);

                return RedirectToAction("List", "Contract");
            }
        }

        [HttpGet]
        [Authorize(Policy = "terminationContract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<TerminationContractUpdateDto>(await _contractService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);
            ViewBag.positions = _map.Map<ICollection<PositionListDto>>(await _positionService.GetAllAsync(x => x.IsDeleted  == false && x.DepartmentId == usr.DepartmentId));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.contractFiles = await _contractFileService.GetAllIncCompAsync(x => x.TerminationContractId == id && !x.IsDeleted);
            ViewBag.terminationItems = await _terminationItemService.GetAllAsync(x => !x.IsDeleted);
            return View(listModel);
        }

     
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserVacationType(int id)
        {
            var vc = await _vacationTypeService.FindByIdAsync(id);
            return Ok(vc.Key);
        }


        [HttpPost]
        [Authorize(Policy = "terminationContract.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TerminationContractUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List", "Contract");
            }
            else
            {
                var current = GetSignInUserId();
                model.UpdateDate = DateTime.UtcNow.AddHours(4);
                model.UpdateByUserId = current;
                await _contractService.UpdateAsync(_map.Map<TerminationContract>(model));

                var usr = await _userService.FindByUserAllInc(model.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());
                DateTime work_start_date = usr.StartWorkDate;
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                // Alqoritm for il ay gun
                TimeSpanToDateParts(DateTime.Now, work_start_date, out int years, out int months, out int days, out int hours, out int minutes);
                var work_range = (years != 0 ? years + " il " : "") + (months != 0 ? months + " ay " : "") + (days != 0 ? days + " gün" : "");
                formatKeys.Add("workRange", work_range);
                var outOfWork = "";
                var notificationWork = "0.5 misli";
                if (years >= 1 && years < 5)
                {
                    outOfWork = "1.4 misli";
                    notificationWork = "0.9 misli";
                }
                else if (years >= 5 && years < 10)
                {
                    outOfWork = "1.7 misli";
                    notificationWork = "1.4 misli";
                }
                else if (years >= 10)
                {
                    outOfWork = "iki misli";
                    notificationWork = "iki misli";
                }
                formatKeys.Add("outOfWork", outOfWork);
                formatKeys.Add("notificationWork", notificationWork);

                formatKeys.Add("vacDayCount", GetRemainVacDay(model.UserId).ToString());
                formatKeys.Add("trItem", _terminationItemService.FindByIdAsync(model.TerminationItemId).Result.Name);
                formatKeys.Add("isAgree", model.IsAgree ? "bildirmişdir" : "bildirməmişdir");
                formatKeys.Add("contractBase", model.Description);
                formatKeys.Add("terminationDate", model.TerminationDate.ToString("dd.MM.yyyy"));
                if (model.ReductionDate != null)
                    formatKeys.Add("reductionDate", ((DateTime)model.ReductionDate).ToString("dd.MM.yyyy"));
                formatKeys.Add("reductionNumber", model.ReductionNumber);
                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", model.CommandNumber);

                var doc_key = ContractFileReadyConst.termination_base;
                if (model.IsReduction)
                {
                    if (model.IsAgree)
                    {
                        doc_key = ContractFileReadyConst.termination_reduction_agree;
                    }
                    else
                    {
                        doc_key = ContractFileReadyConst.termination_reduction_not_agree;
                    }
                }
                usr = await _userService.FindByUserAllInc(model.UserId);
                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
              
                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.TerminationContractId == model.Id && !x.IsDeleted);
                foreach (var el in contract_files)
                {
                    var clause = _clauseService.GetAllIncCompAsync(x => x.Key == doc_key && !x.IsDeleted).Result[0];
                    var edit_el = _contractFileService.FindByIdAsync(el.Id).Result;
                    DeleteFile("wwwroot/contractDocs/", el.FilePath);
                    edit_el.ClauseId = clause.Id;
                    StringBuilder content = await GetDocxContent(clause.FilePath, formatKeys);
                    edit_el.FilePath = await AddContractFile(clause.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.UpdateAsync(edit_el);
                }
                return RedirectToAction("List", "Contract");
            }
        }

        [Authorize(Policy = "terminationContract.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var current = GetSignInUserId();
            var transactionModel = _map.Map<TerminationContractListDto>(await _contractService.FindByIdAsync(id));
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _contractService.UpdateAsync(_map.Map<TerminationContract>(transactionModel));
          
            return RedirectToAction("List", "Contract");

        }

        // helper
        public void TimeSpanToDateParts(DateTime d1, DateTime d2, out int years, out int months, out int days, out int hours, out int minutes)
        {
            if (d1 < d2)
            {
                var d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            var span = d1 - d2;

            months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);

            if (d1.CompareTo(d2.AddMonths(months).AddMilliseconds(-500)) <= 0)
            {
                --months;
            }

            years = months / 12;
            months -= years * 12;

            if (months == 0 && years == 0)
            {
                days = span.Days;
            }
            else
            {
                var md1 = new DateTime(d1.Year, d1.Month, d1.Day);
                // Fixed to use d2.Day instead of d1.Day
                var md2 = new DateTime(d2.Year, d2.Month, d2.Day);
                var mDays = (int)(md1 - md2).TotalDays;

                if (mDays > span.Days)
                {
                    mDays = (int)(md1.AddMonths(-1) - md2).TotalDays;
                }

                days = span.Days - mDays;


            }
            hours = span.Hours;
            minutes = span.Minutes;
        }

        // vacation remain day
        public decimal GetRemainVacDay(int user_id)
        {
            decimal result_remain_day = 0;
            var vc =  _userVacationRemainService.GetAllAsync(x => !x.IsDeleted && x.RemainCount != 0 && x.AppUserId == user_id).Result;
            var remain_list = vc.ToList().OrderBy(x => x.FromDate).ToList();
            var usr = _userManager.FindByIdAsync(user_id.ToString()).Result;
            var work_start_date = usr.StartWorkDate;

            if (work_start_date != null)
            {
                DateTime start_interval;
                DateTime end_interval;
                if (DateTime.Now.Month > work_start_date.Month || (DateTime.Now.Month == work_start_date.Month && DateTime.Now.Day >= work_start_date.Day))
                {
                    start_interval = new DateTime(DateTime.Now.Year, work_start_date.Month, work_start_date.Day);
                    end_interval = new DateTime(DateTime.Now.Year + 1, work_start_date.Month, work_start_date.Day);
                }
                else
                {
                    start_interval = new DateTime(DateTime.Now.Year - 1, work_start_date.Month, work_start_date.Day);
                    end_interval = new DateTime(DateTime.Now.Year, work_start_date.Month, work_start_date.Day);
                }

                var personal_contract_chgs = _personalContractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == user_id && x.Type == PersonalContractConst.VACATION && x.CommandDate >= start_interval && x.CommandDate <= end_interval && x.IsMainVacation).Result;


                if (!remain_list.Any(el => el.FromDate == start_interval && el.ToDate == end_interval))
                {
                    UserVacationRemain ur = new UserVacationRemain();
                    ur.FromDate = start_interval;
                    ur.ToDate = end_interval;
                    ur.IsDeleted = false;
                    ur.CreatedDate = DateTime.Now;
                    ur.AppUserId = user_id;
                    ur.UsedCount = 0;
                    ur.VacationCount = usr.VacationMainDay;
                        //+ usr.VacationExtraChild + usr.VacationExtraExperience + usr.VacationExtraNature;
                    ur.RemainCount = ur.VacationCount;
                    remain_list.Add(ur);
                     _userVacationRemainService.AddAsync(ur);
                }

                decimal this_year_remain = 0;
                foreach (var el in remain_list)
                {

                    if (el.FromDate == start_interval && el.ToDate == end_interval)
                    {
                        this_year_remain += el.UsedCount;
                    }
                    else
                    {
                        result_remain_day += el.RemainCount;
                    }
                }


                if (personal_contract_chgs.Count() > 0)
                {
                    DateTime fromDateTmp = start_interval;

                    var main_day = 0;
                    foreach (var el in personal_contract_chgs)
                    {
                        if (el.CommandDate <= DateTime.Now)
                        {
                            double before_day_count = Math.Round((double)((el.CommandDate - fromDateTmp).TotalDays) * el.VacationDay) / 365;
                            result_remain_day += (int)before_day_count;
                            fromDateTmp = el.CommandDate;
                            main_day = (int)el.LastMainVacationDay;
                        }

                    }

                    double after_day_count = Math.Round((double)((DateTime.Now - fromDateTmp).TotalDays) * main_day) / 365;
                    result_remain_day += (int)after_day_count;
                    //result_remain_day += usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                }
                else
                {
                    double after_day_count = Math.Round((double)((DateTime.Now - start_interval).TotalDays) * usr.VacationMainDay) / 365;
                    result_remain_day += (int)after_day_count;
                    //result_remain_day += usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                }

                result_remain_day -= this_year_remain;
               

            }

            return result_remain_day;
        }

    }
}
