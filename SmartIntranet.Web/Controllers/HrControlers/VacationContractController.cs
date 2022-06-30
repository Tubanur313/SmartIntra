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
using HtmlConverter = iText.Html2pdf.HtmlConverter;
using SmartIntranet.Business.Interfaces.Intranet;

namespace SmartIntranet.Web.Controllers
{
    public class VacationContractController : BaseIdentityController
    {
        private readonly IVacationContractService _contractService;
        private readonly IVacationContractFileService _contractFileService;
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

        public VacationContractController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IVacationContractService contractService, IVacationContractFileService contractFileService, INonWOrkingYearService nonWorkingYearService, INonWorkingDayService nonWorkingDayService, IPersonalContractService personalContractService, IClauseService clauseService, IContractTypeService contractTypeService, IUserVacationRemainService userVacationRemainService, IAppUserService userService, IVacationTypeService vacationTypeService, IWorkGraphicService workGraphicService, IPositionService positionService, ICompanyService companyService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _contractService = contractService;
            _contractTypeService = contractTypeService;
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
        [Authorize(Policy = "vacationContract.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.vacationTypes = await _vacationTypeService.GetAllAsync(x => !x.IsDeleted);
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "vacationContract.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VacationContractAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.IsDeleted = false;
                model.CreatedDate = DateTime.Now;
                var doc_key = "";

                var vac_type = _vacationTypeService.FindByIdAsync(model.VacationTypeId).Result.Key;
                if (vac_type == VacationTypeConst.LABOR)
                {
                    doc_key = ContractFileReadyConst.vacation_labor;
                    await DelVacPersonalAfterDate(model.UserId, model.CommandDate);
                }
                else if (vac_type == VacationTypeConst.EDU)
                {
                    doc_key = ContractFileReadyConst.vacation_edu;
                }
                else if (vac_type == VacationTypeConst.WITHOUT_PRICE)
                {
                    doc_key = ContractFileReadyConst.vacation_without_price;
                }
                else if (vac_type == VacationTypeConst.PREGNANCY)
                {
                    doc_key = ContractFileReadyConst.vacation_pregnancy;
                }
                else if (vac_type == VacationTypeConst.SOCIAL)
                {
                    doc_key = ContractFileReadyConst.vacation_social;
                }


                var current = GetSignInUserId();
                var result_model = _contractService.AddReturnEntityAsync(_map.Map<VacationContract>(model)).Result;
                var usr = await _userService.FindByUserAllInc(result_model.UserId);
                var usr2 = await _userManager.FindByIdAsync(result_model.UserId.ToString());
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());
                DateTime work_start_date = usr.StartWorkDate;
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

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
                    var graph = _workGraphicService.FindByIdAsync((int)usr.WorkGraphicId).Result;

                    var next_date = model.ToDate.AddDays(1);
                    var vacation_type = _vacationTypeService.FindByIdAsync(model.VacationTypeId).Result;
                    if (vacation_type.Key == VacationTypeConst.LABOR)
                    {
                        var last_year_days = _nonWorkingDayService.GetAllIncCompAsync(x => x.NonWorkingYear.Year == start_interval.Year.ToString() && !x.IsDeleted).Result;

                        var next_year_days = _nonWorkingDayService.GetAllIncCompAsync(x => x.NonWorkingYear.Year == end_interval.Year.ToString() && !x.IsDeleted).Result;

                        //last_year_days = last_year_days.Where(x => x.StartDate <= model.FromDate).ToList();

                        //next_year_days = next_year_days.Where(x => x.EndDate.Month <= model.ToDate.Month).ToList();
                      
                        Dictionary<DateTime, bool> date_list = new Dictionary<DateTime, bool>();
                        bool flag = false;
                        DateTime date_item = model.FromDate;
                        while (!flag)
                        {
                            date_list.Add(date_item, false);
                            date_item = date_item.AddDays(1);
                            if (date_item == model.ToDate.AddDays(1))
                            {
                                flag = true;
                            }
                        }

                        foreach (var day in date_list.ToList())
                        {
                            if (last_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                            {
                                date_list[day.Key] = true;
                            }
                            else if (next_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                            {
                                date_list[day.Key] = true;
                            }
                        }

                        var next_to_day = date_list.Where(x => x.Value).Count();
                        if (next_to_day > 0)
                        {
                            Dictionary<DateTime, bool> remain_date_list = new Dictionary<DateTime, bool>();
                            flag = false;
                            DateTime remain_date_item = model.FromDate.AddDays(1);
                            while (!flag)
                            {
                                remain_date_list.Add(remain_date_item, false);
                                remain_date_item = remain_date_item.AddDays(1);
                                if (remain_date_item == model.FromDate.AddDays(next_to_day + 1))
                                {
                                    flag = true;
                                }
                            }

                            foreach (var day in remain_date_list)
                            {
                                if (last_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                                {
                                    date_list[day.Key] = true;
                                }
                                else if (next_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                                {
                                    date_list[day.Key] = true;
                                }
                            }

                            next_to_day += remain_date_list.Where(x => x.Value).Count();
                            next_date = next_date.AddDays(next_to_day);

                            var week_day = next_date.DayOfWeek;
                            if (graph.Key == "five_day")
                            {
                                if (week_day == DayOfWeek.Saturday)
                                {
                                    next_date = next_date.AddDays(2);
                                }
                                else if (week_day == DayOfWeek.Sunday)
                                {
                                    next_date = next_date.AddDays(1);
                                }
                            }
                            else if (graph.Key == "six_day")
                            {
                                if (week_day == DayOfWeek.Sunday)
                                {
                                    next_date = next_date.AddDays(1);
                                }
                            }

                            if (last_year_days.Any(x => x.StartDate <= next_date && next_date <= x.EndDate))
                            {
                                next_date = last_year_days.FirstOrDefault(x => x.StartDate <= next_date && next_date <= x.EndDate).EndDate.AddDays(1);
                            }
                            else if (next_year_days.Any(x => x.StartDate <= next_date && next_date <= x.EndDate))
                            {
                                next_date = next_year_days.FirstOrDefault(x => x.StartDate <= next_date && next_date <= x.EndDate).EndDate.AddDays(1);
                            }

                        }
                        var remain_from_date = (DateTime)model.FromWorkYearDate; 
                        var remain_to_date = (DateTime)model.ToWorkYearDate;

                        formatKeys.Add("remainFromDate", remain_from_date.ToString("dd.MM.yyyy"));
                        formatKeys.Add("remainToDate", remain_to_date.ToString("dd.MM.yyyy"));
                        var diff = remain_to_date.Year - remain_from_date.Year;
                        if (diff == 1)
                        {
                            var user_vacation_remain = _userVacationRemainService.GetAllIncCompAsync(x => !x.IsDeleted && x.FromDate.Year == remain_from_date.Year && x.ToDate.Year == remain_to_date.Year && x.AppUserId == model.UserId).Result;

                            var usr_vr = _userVacationRemainService.FindByIdAsync(user_vacation_remain[0].Id).Result;
                            usr_vr.UsedCount += model.CalendarDay;
                            usr_vr.RemainCount -= model.CalendarDay;
                            await _userVacationRemainService.UpdateAsync(usr_vr);
                        }
                        else
                        {
                            var active_year = remain_from_date.Year;
                            decimal keep_count = 0;
                            while (diff != 0)
                            {
                                var user_vacation_remain = _userVacationRemainService.GetAllIncCompAsync(x => !x.IsDeleted && x.FromDate.Year == active_year && x.AppUserId == model.UserId).Result;
                                var usr_vr = _userVacationRemainService.FindByIdAsync(user_vacation_remain[0].Id).Result;

                                if (diff != 1)
                                {
                                    keep_count += usr_vr.RemainCount;
                                    usr_vr.UsedCount += usr_vr.RemainCount;
                                    usr_vr.RemainCount = 0;
                                }
                                else
                                {
                                    usr_vr.UsedCount += model.CalendarDay - keep_count;
                                    usr_vr.RemainCount -= model.CalendarDay - keep_count;
                                }
                               
                                await _userVacationRemainService.UpdateAsync(usr_vr);
                                diff--;
                                active_year += 1;
                            }
                        }
                    }
                   
                 
                    formatKeys.Add("fromVacDate", model.FromDate.ToString("dd.MM.yyyy"));
                    formatKeys.Add("toVacDate", model.ToDate.ToString("dd.MM.yyyy"));
                    formatKeys.Add("vacDayCount", model.CalendarDay.ToString());
                    formatKeys.Add("contractBase", model.Description);
                    formatKeys.Add("nextWorkDate", next_date.ToString("dd.MM.yyyy"));
                    model.NextWorkDate = next_date;
                    await _contractService.UpdateAsync(_map.Map<VacationContract>(result_model));

                }
               
                formatKeys.Add("commandDate", result_model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", result_model.CommandNumber);
                usr = await _userService.FindByUserAllInc(model.UserId);
                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
              
                var file_extra = new VacationContractFile();
                file_extra.VacationContractId = result_model.Id;
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
        [Authorize(Policy = "vacationContract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<VacationContractUpdateDto>(await _contractService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);
            ViewBag.positions = _map.Map<ICollection<PositionListDto>>(await _positionService.GetAllAsync(x => x.IsDeleted  == false && x.DepartmentId == usr.DepartmentId));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.contractFiles = await _contractFileService.GetAllIncCompAsync(x => x.VacationContractId == id && !x.IsDeleted);
            ViewBag.vacationTypes = await _vacationTypeService.GetAllAsync(x => !x.IsDeleted);
            return View(listModel);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            long aa = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserVacationRemainDates(string fromDate, string toDate, int user_id)
        {
            DateTime from_date = UnixTimeStampToDateTime(Double.Parse(fromDate));
            DateTime to_date = UnixTimeStampToDateTime(Double.Parse(toDate));

            var result = new UserVacationRemainDates();

            var vc = await _userVacationRemainService.GetAllAsync(x => !x.IsDeleted && x.RemainCount != 0 && x.AppUserId == user_id);
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


                decimal calendarDay = 0;
                decimal selectedCalendarDay = 0;
                if (from_date>=start_interval && from_date <=end_interval && to_date>= start_interval && to_date<= end_interval)
                {
                    calendarDay = (int)(to_date - from_date).TotalDays + 1;
                    selectedCalendarDay = (int)(to_date - from_date).TotalDays + 1;
                }
                else
                {
                    result.Message = "Cari məzuniyyət ili daxilində məzuniyyət götürə bilərsiniz!";
                }

               
                bool isFlag = false;
                decimal this_year_remain = 0;
                if(!remain_list.Any(el=> el.FromDate == start_interval && el.ToDate == end_interval))
                {
                    UserVacationRemain ur = new UserVacationRemain();
                    ur.FromDate = start_interval;
                    ur.ToDate = end_interval;
                    ur.IsDeleted = false;
                    ur.CreatedDate = DateTime.Now;
                    ur.AppUserId = user_id;
                    ur.UsedCount = 0;
                    ur.VacationCount = usr.VacationMainDay + usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                    ur.RemainCount = ur.VacationCount;
                    remain_list.Add(ur);
                    await _userVacationRemainService.AddAsync(ur);
                }
                foreach (var el in remain_list)
                {
                    if(!(el.FromDate == start_interval && el.ToDate == end_interval))
                    {
                        result.RemainCount += el.RemainCount;
                    }
                    else
                    {
                        this_year_remain += el.UsedCount;
                    }
                    
                  
                   
                    if (result.ToDate == null)
                    {
                        if (calendarDay > el.RemainCount)
                        {
                           calendarDay -= el.RemainCount;
                        }
                        else
                        {
                            result.ToDate = el.ToDate;
                        }
                    }
                  

                }

               
                if (remain_list.Count() > 0)
                {
                    result.FromDate = remain_list[0].FromDate;
                }

                if (personal_contract_chgs.Count() > 0)
                {
                    DateTime fromDateTmp = start_interval;

                    var main_day = 0;
                    foreach (var el in personal_contract_chgs)
                    {
                        if(el.CommandDate<= DateTime.Now)
                        {
                            double before_day_count = Math.Round((double)((el.CommandDate - fromDateTmp).TotalDays) * (int)el.LastMainVacationDay) / 365;
                            result.RemainCount += (int)before_day_count;
                            fromDateTmp = el.CommandDate;
                            main_day = (int)el.VacationDay;
                        }
                     
                    }

                    double after_day_count = Math.Round((double)((DateTime.Now - fromDateTmp).TotalDays) * main_day) / 365;
                    result.RemainCount += (int)after_day_count;
                    result.RemainCount += usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                }
                else
                {
                    double after_day_count = Math.Round((double)((DateTime.Now - start_interval).TotalDays) * usr.VacationMainDay) / 365;
                    result.RemainCount += (int)after_day_count;
                    result.RemainCount += usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                }
                result.RemainCount -= this_year_remain;
               
                if (!(calendarDay != 0 && selectedCalendarDay <= result.RemainCount))
                {
                   // result.ToDate = end_interval;
                  result.Message = "Məzuniyyət günü götürmə limitinizi aşırsınız!";
                }
            }


            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserVacationType(int id)
        {
            var vc = await _vacationTypeService.FindByIdAsync(id);
            return Ok(vc.Key);
        }


        [HttpPost]
        [Authorize(Policy = "vacationContract.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VacationContractUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List", "Contract");
            }
            else
            {
                var current = GetSignInUserId();
                model.UpdateDate = DateTime.Now;
                model.UpdateByUserId = current;
                await _contractService.UpdateAsync(_map.Map<VacationContract>(model));
                var doc_key = "";
                var vac_type = _vacationTypeService.FindByIdAsync(model.VacationTypeId).Result.Key;

                if (vac_type == VacationTypeConst.LABOR)
                {
                    doc_key = ContractFileReadyConst.vacation_labor;
                    await DelVacPersonalAfterDate(model.UserId, model.CommandDate);
                }
                else if (vac_type == VacationTypeConst.EDU)
                {
                    doc_key = ContractFileReadyConst.vacation_edu;
                }
                else if (vac_type == VacationTypeConst.WITHOUT_PRICE)
                {
                    doc_key = ContractFileReadyConst.vacation_without_price;
                }
                else if (vac_type == VacationTypeConst.PREGNANCY)
                {
                    doc_key = ContractFileReadyConst.vacation_pregnancy;
                }
                else if (vac_type == VacationTypeConst.SOCIAL)
                {
                    doc_key = ContractFileReadyConst.vacation_social;
                }

                var usr = await _userService.FindByUserAllInc(model.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());
                DateTime work_start_date = usr.StartWorkDate;
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

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
                    var graph = _workGraphicService.FindByIdAsync((int)usr.WorkGraphicId).Result;

                    var next_date = model.ToDate.AddDays(1);
                    var vacation_type = _vacationTypeService.FindByIdAsync(model.VacationTypeId).Result;
                    if (vacation_type.Key == VacationTypeConst.LABOR)
                    {
                        var last_year_days = _nonWorkingDayService.GetAllIncCompAsync(x => x.NonWorkingYear.Year == start_interval.Year.ToString() && !x.IsDeleted).Result;

                        var next_year_days = _nonWorkingDayService.GetAllIncCompAsync(x => x.NonWorkingYear.Year == end_interval.Year.ToString() && !x.IsDeleted).Result;

                        //last_year_days = last_year_days.Where(x => x.StartDate <= model.FromDate).ToList();

                        //next_year_days = next_year_days.Where(x => x.EndDate.Month <= model.ToDate.Month).ToList();

                        Dictionary<DateTime, bool> date_list = new Dictionary<DateTime, bool>();
                        bool flag = false;
                        DateTime date_item = model.FromDate;
                        while (!flag)
                        {
                            date_list.Add(date_item, false);
                            date_item = date_item.AddDays(1);
                            if (date_item == model.ToDate.AddDays(1))
                            {
                                flag = true;
                            }
                        }

                        foreach (var day in date_list.ToList())
                        {
                            if (last_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                            {
                                date_list[day.Key] = true;
                            }
                            else if (next_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                            {
                                date_list[day.Key] = true;
                            }
                        }

                        var next_to_day = date_list.Where(x => x.Value).Count();
                        if (next_to_day > 0)
                        {
                            Dictionary<DateTime, bool> remain_date_list = new Dictionary<DateTime, bool>();
                            flag = false;
                            DateTime remain_date_item = model.FromDate.AddDays(1);
                            while (!flag)
                            {
                                remain_date_list.Add(remain_date_item, false);
                                remain_date_item = remain_date_item.AddDays(1);
                                if (remain_date_item == model.FromDate.AddDays(next_to_day + 1))
                                {
                                    flag = true;
                                }
                            }

                            foreach (var day in remain_date_list)
                            {
                                if (last_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                                {
                                    date_list[day.Key] = true;
                                }
                                else if (next_year_days.Any(x => x.StartDate <= day.Key && day.Key <= x.EndDate))
                                {
                                    date_list[day.Key] = true;
                                }
                            }

                            next_to_day += remain_date_list.Where(x => x.Value).Count();
                            next_date = next_date.AddDays(next_to_day);

                            var week_day = next_date.DayOfWeek;
                            if (graph.Key == "five_day")
                            {
                                if (week_day == DayOfWeek.Saturday)
                                {
                                    next_date = next_date.AddDays(2);
                                }
                                else if (week_day == DayOfWeek.Sunday)
                                {
                                    next_date = next_date.AddDays(1);
                                }
                            }
                            else if (graph.Key == "six_day")
                            {
                                if (week_day == DayOfWeek.Sunday)
                                {
                                    next_date = next_date.AddDays(1);
                                }
                            }
                            if (last_year_days.Any(x => x.StartDate <= next_date && next_date <= x.EndDate))
                            {
                                next_date = last_year_days.FirstOrDefault(x => x.StartDate <= next_date && next_date <= x.EndDate).EndDate.AddDays(1);
                            }
                            else if (next_year_days.Any(x => x.StartDate <= next_date && next_date <= x.EndDate))
                            {
                                next_date = next_year_days.FirstOrDefault(x => x.StartDate <= next_date && next_date <= x.EndDate).EndDate.AddDays(1);
                            }

                        }
                        var remain_from_date = (DateTime)model.FromWorkYearDate;
                        var remain_to_date = (DateTime)model.ToWorkYearDate;

                        formatKeys.Add("remainFromDate", remain_from_date.ToString("dd.MM.yyyy"));
                        formatKeys.Add("remainToDate", remain_to_date.ToString("dd.MM.yyyy"));
                        var diff = remain_to_date.Year - remain_from_date.Year;
                        if (diff == 1)
                        {
                            var user_vacation_remain = _userVacationRemainService.GetAllIncCompAsync(x => !x.IsDeleted && x.FromDate.Year == remain_from_date.Year && x.ToDate.Year == remain_to_date.Year && x.AppUserId == model.UserId).Result;

                            var usr_vr = _userVacationRemainService.FindByIdAsync(user_vacation_remain[0].Id).Result;
                            usr_vr.UsedCount += model.CalendarDay;
                            usr_vr.RemainCount -= model.CalendarDay;
                            await _userVacationRemainService.UpdateAsync(usr_vr);
                        }
                        else
                        {
                            var active_year = remain_from_date.Year;
                            decimal keep_count = 0;
                            while (diff != 0)
                            {
                                var user_vacation_remain = _userVacationRemainService.GetAllIncCompAsync(x => !x.IsDeleted && x.FromDate.Year == active_year && x.AppUserId == model.UserId).Result;
                                var usr_vr = _userVacationRemainService.FindByIdAsync(user_vacation_remain[0].Id).Result;

                                if (diff != 1)
                                {
                                    keep_count += usr_vr.RemainCount;
                                    usr_vr.UsedCount += usr_vr.RemainCount;
                                    usr_vr.RemainCount = 0;
                                }
                                else
                                {
                                    usr_vr.UsedCount += model.CalendarDay - keep_count;
                                    usr_vr.RemainCount -= model.CalendarDay - keep_count;
                                }

                                await _userVacationRemainService.UpdateAsync(usr_vr);
                                diff--;
                                active_year += 1;
                            }
                        }
                    }

                  
                    formatKeys.Add("fromVacDate", model.FromDate.ToString("dd.MM.yyyy"));
                    formatKeys.Add("toVacDate", model.ToDate.ToString("dd.MM.yyyy"));
                    formatKeys.Add("vacDayCount", model.CalendarDay.ToString());
                    formatKeys.Add("contractBase", model.Description);
                    formatKeys.Add("nextWorkDate", next_date.ToString("dd.MM.yyyy"));
                    model.NextWorkDate = next_date;
                    await _contractService.UpdateAsync(_map.Map<VacationContract>(model));

                }

                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", model.CommandNumber);
                usr = await _userService.FindByUserAllInc(model.UserId);
                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
               

                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.VacationContractId == model.Id && !x.IsDeleted);
                foreach (var el in contract_files)
                {
                    var clause = _clauseService.GetAllIncCompAsync(x => x.Key == doc_key && !x.IsDeleted).Result[0];
                    DeleteFile("wwwroot/contractDocs/", el.FilePath);
                    StringBuilder content = await GetDocxContent(el.Clause.FilePath, formatKeys);
                    el.FilePath = await AddContractFile(el.Clause.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.UpdateAsync(el);
                }
                return RedirectToAction("List", "Contract");
            }
        }

        [Authorize(Policy = "vacationContract.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var current = GetSignInUserId();
            var transactionModel = _map.Map<VacationContractListDto>(await _contractService.FindByIdAsync(id));
            var vacation_type = _vacationTypeService.FindByIdAsync(transactionModel.VacationTypeId).Result;
         
            if (vacation_type.Key == VacationTypeConst.LABOR)
            {
                await DelVacPersonalAfterDate(transactionModel.UserId, transactionModel.CommandDate);
 
            }

            transactionModel.DeleteDate = DateTime.Now.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _contractService.UpdateAsync(_map.Map<VacationContract>(transactionModel));

            return Ok();

        }


        public async Task DelVacPersonalAfterDate(int userId, DateTime commandDate)
        {
            var current = GetSignInUserId();

            var usr2 = await _userManager.FindByIdAsync(userId.ToString());

            var personal_contract_chgs = _personalContractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == usr2.Id && x.Type == PersonalContractConst.VACATION && x.CommandDate > commandDate).Result.OrderBy(x => x.CommandDate).ToList();

            if(personal_contract_chgs.Count() > 0)
            {
                usr2.VacationMainDay = (int)personal_contract_chgs[0].LastMainVacationDay;
                if (!personal_contract_chgs[0].IsMainVacation)
                {
                    var diff = (int)personal_contract_chgs[0].NewFullVacationDay - (int)personal_contract_chgs[0].LastFullVacationDay;
                    if (personal_contract_chgs[0].VacationExtraType == 0)
                    {
                        usr2.VacationExtraExperience = (int)personal_contract_chgs[0].VacationDay - diff;
                    }
                    else if (personal_contract_chgs[0].VacationExtraType == 1)
                    {
                        usr2.VacationExtraNature = (int)personal_contract_chgs[0].VacationDay - diff;
                    }
                    else if (personal_contract_chgs[0].VacationExtraType == 2)
                    {
                        usr2.VacationExtraChild = (int)personal_contract_chgs[0].VacationDay - diff;
                    }
                }
                await _userManager.UpdateAsync(usr2);
            }
          

            foreach (var el in personal_contract_chgs)
            {
                var el_del = _personalContractService.FindByIdAsync(el.Id).Result;
                el_del.DeleteDate = DateTime.Now.AddHours(4);
                el_del.DeleteByUserId = current;
                el_del.IsDeleted = true;
                await _personalContractService.UpdateAsync(_map.Map<PersonalContract>(el_del));
            }

            var del_list = _contractService.GetAllIncCompAsync(x => x.CommandDate > commandDate).Result;
            decimal day_count = 0;
            foreach (var el in del_list)
            {
                if (el.VacationType.Key == VacationTypeConst.LABOR)
                {
                    day_count += el.CalendarDay;
                }
                el.DeleteDate = DateTime.Now.AddHours(4);
                el.DeleteByUserId = current;
                el.IsDeleted = true;
                await _contractService.UpdateAsync(_map.Map<VacationContract>(el));
            }

            var this_item = _contractService.GetAllIncCompAsync(x => x.CommandDate == commandDate).Result;
            if (this_item.Count() > 0)
            {
                day_count += this_item[0].CalendarDay;
            }

            var remain_list = _userVacationRemainService.GetAllIncCompAsync(x => x.AppUserId == usr2.Id && !x.IsDeleted).Result.OrderBy(x => x.FromDate);

            int i = 0;
            foreach (var el in remain_list)
            {
                if (i == 0)
                {
                    el.VacationCount = usr2.VacationExtraChild + usr2.VacationExtraExperience + usr2.VacationExtraNature + usr2.VacationMainDay;
                    el.RemainCount = el.VacationCount - el.UsedCount;
                }

                if (day_count >= el.UsedCount)
                {
                    day_count -= el.UsedCount;
                    el.RemainCount += el.UsedCount;
                    el.UsedCount = 0;
                    await _userVacationRemainService.UpdateAsync(el);
                }
                else
                {

                    el.UsedCount -= day_count;
                    el.RemainCount += day_count;
                    await _userVacationRemainService.UpdateAsync(el);
                    day_count = 0;
                }

                if (day_count == 0)
                {
                    break;
                }
                i++;
            }



        }

    }
}
