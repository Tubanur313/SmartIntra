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
    public class PersonalContractController : BaseIdentityController
    {
        private readonly IntranetContext _db;
        private readonly IPersonalContractService _contractService;
        private readonly IVacationContractService _vacationContractService;
        private readonly IUserVacationRemainService _userVacationRemains;
        private readonly IPersonalContractFileService _contractFileService;
        private readonly IContractTypeService _contractTypeService;
        private readonly IClauseService _clauseService;
        private readonly IAppUserService _userService;
        private readonly IWorkGraphicService _workGraphicService;
        private readonly IPositionService _positionService;
        private readonly ICompanyService _companyService;

        public PersonalContractController(UserManager<IntranetUser> userManager, IntranetContext db, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IUserVacationRemainService userVacationRemains, IMapper mapper, IPersonalContractService contractService, IVacationContractService vacationContractService, IPersonalContractFileService contractFileService, IClauseService clauseService, IContractTypeService contractTypeService, IAppUserService userService, IWorkGraphicService workGraphicService, IPositionService positionService, ICompanyService companyService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _db = db;
            _contractService = contractService;
            _vacationContractService = vacationContractService;
            _contractTypeService = contractTypeService;
            _contractFileService = contractFileService;
            _userVacationRemains = userVacationRemains;
            _userService = userService;
            _clauseService = clauseService;
            _workGraphicService = workGraphicService;
            _positionService = positionService;
            _companyService = companyService;
        }


        [HttpGet]
        [Authorize(Policy = "personalContract.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.clauses = await _clauseService.GetAllAsync(x => !x.IsDeleted && !x.IsBackground);
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "personalContract.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PersonalContractAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var usr2 = await _userManager.FindByIdAsync(model.UserId.ToString());
                model.IsDeleted = false;
                model.CreatedDate = DateTime.Now;
               
                if (model.Type == PersonalContractConst.VACATION)
                {
                    model.LastFullVacationDay = usr2.VacationMainDay + usr2.VacationExtraExperience + usr2.VacationExtraNature
                        + usr2.VacationExtraChild;
                    model.LastMainVacationDay = usr2.VacationMainDay;

                    if (model.IsMainVacation)
                    {
                        model.NewFullVacationDay = model.VacationDay + usr2.VacationExtraExperience + usr2.VacationExtraNature
                        + usr2.VacationExtraChild;
                        model.NewMainVacationDay = model.VacationDay;
                    }
                    else
                    {
                        model.NewFullVacationDay = model.VacationDay + usr2.VacationMainDay;
                        model.NewMainVacationDay = usr2.VacationMainDay;
                    }
                }else if (model.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    model.LastWorkGraphicId = usr2.WorkGraphicId;
                }

                // Emek muqavile senedi
                var current = GetSignInUserId();
                var result_model = _contractService.AddReturnEntityAsync(_map.Map<PersonalContract>(model)).Result;
                var usr = await _userService.FindByUserAllInc(result_model.UserId);

                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                formatKeys.Add("commandDate", result_model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", result_model.CommandNumber);

                if (model.Type == PersonalContractConst.SALARY)
                {
                    usr2.Salary = (double)result_model.Salary;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clauseExtra = ContractFileReadyConst.personal_change_extra_salary;
                    var clauseCommand = ContractFileReadyConst.personal_change_command_salary;

                    var file_extra = new PersonalContractFile();
                    file_extra.PersonalContractId = result_model.Id;
                    file_extra.IsDeleted = false;

                    var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseExtra && !x.IsDeleted))[0];
                    file_extra.ClauseId = clause_result_extra.Id;
                    StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                    file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                    await _contractFileService.AddAsync(file_extra);

                    var file_command = new PersonalContractFile();
                    file_command.PersonalContractId = result_model.Id;
                    file_command.IsDeleted = false;

                    var clause_result_command = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseCommand && !x.IsDeleted))[0];
                    file_command.ClauseId = clause_result_command.Id;
                    StringBuilder content_command = await GetDocxContent(clause_result_command.FilePath, formatKeys);
                    file_command.FilePath = await AddContractFile(clause_result_command.FilePath, PdfFormatKeys(formatKeys, content_command));
                    await _contractFileService.AddAsync(file_command);
                }
                else if (model.Type== PersonalContractConst.POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.PositionId = result_model.PositionId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clauseExtra = ContractFileReadyConst.personal_change_extra_position;
                    var clauseCommand = ContractFileReadyConst.personal_change_command_position;

                    var file_extra = new PersonalContractFile();
                    file_extra.PersonalContractId = result_model.Id;
                    file_extra.IsDeleted = false;

                    var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseExtra && !x.IsDeleted))[0];
                    file_extra.ClauseId = clause_result_extra.Id;
                    StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                    file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                    await _contractFileService.AddAsync(file_extra);

                    var file_command = new PersonalContractFile();
                    file_command.PersonalContractId = result_model.Id;
                    file_command.IsDeleted = false;

                    var clause_result_command = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseCommand && !x.IsDeleted))[0];
                    file_command.ClauseId = clause_result_command.Id;
                    StringBuilder content_command = await GetDocxContent(clause_result_command.FilePath, formatKeys);
                    file_command.FilePath = await AddContractFile(clause_result_command.FilePath, PdfFormatKeys(formatKeys, content_command));
                    await _contractFileService.AddAsync(file_command);
                }
                else if (model.Type == PersonalContractConst.SALARY_POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.Salary = (double)result_model.Salary;
                    usr2.PositionId = result_model.PositionId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clauseExtra = ContractFileReadyConst.personal_change_extra_salary_position;
                    var clauseCommand = ContractFileReadyConst.personal_change_command_salary_position;

                    var file_extra = new PersonalContractFile();
                    file_extra.PersonalContractId = result_model.Id;
                    file_extra.IsDeleted = false;

                    var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseExtra && !x.IsDeleted))[0];
                    file_extra.ClauseId = clause_result_extra.Id;
                    StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                    file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                    await _contractFileService.AddAsync(file_extra);

                    var file_command = new PersonalContractFile();
                    file_command.PersonalContractId = result_model.Id;
                    file_command.IsDeleted = false;

                    var clause_result_command = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseCommand && !x.IsDeleted))[0];
                    file_command.ClauseId = clause_result_command.Id;
                    StringBuilder content_command = await GetDocxContent(clause_result_command.FilePath, formatKeys);
                    file_command.FilePath = await AddContractFile(clause_result_command.FilePath, PdfFormatKeys(formatKeys, content_command));
                    await _contractFileService.AddAsync(file_command);
                }
                else if (model.Type == PersonalContractConst.WORK_PLACE)
                {
                    formatKeys.Add("workPlace", result_model.IsMainPlace ? "Əsas" : "Əlavə");
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clause = ContractFileReadyConst.personal_work_place;
                    var file = new PersonalContractFile();
                    file.PersonalContractId = result_model.Id;
                    file.IsDeleted = false;
                    var clause_result = (await _clauseService.GetAllIncCompAsync(x => x.Key == clause && !x.IsDeleted))[0];
                    file.ClauseId = clause_result.Id;
                    StringBuilder content = await GetDocxContent(clause_result.FilePath, formatKeys);
                    file.FilePath = await AddContractFile(clause_result.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.AddAsync(file);
                }
                else if (model.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    formatKeys.Add("workPlace", result_model.IsMainPlace ? "Əsas" : "Əlavə");
                    usr2.WorkGraphicId = result_model.WorkGraphicId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var file = new PersonalContractFile();
                    file.PersonalContractId = result_model.Id;
                    file.IsDeleted = false;
                    var clause_result = (await _clauseService.GetAllIncCompAsync(x => x.Id == result_model.ClauseId && !x.IsDeleted))[0];
                    file.ClauseId = clause_result.Id;
                    StringBuilder content = await GetDocxContent(clause_result.FilePath, formatKeys);
                    file.FilePath = await AddContractFile(clause_result.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.AddAsync(file);
                }
                else if (model.Type == PersonalContractConst.VACATION)
                {
                    if (result_model.IsMainVacation)
                    {
                        usr.VacationMainDay = (int)result_model.VacationDay;
                        usr2.VacationMainDay = (int)result_model.VacationDay;
                    }
                    else
                    {
                        if (result_model.VacationExtraType == 0)
                        {
                            usr.VacationExtraExperience = (int)result_model.VacationDay;
                            usr2.VacationExtraExperience = (int)result_model.VacationDay;
                        }else if (result_model.VacationExtraType == 1)
                        {
                            usr.VacationExtraNature = (int)result_model.VacationDay;
                            usr2.VacationExtraNature = (int)result_model.VacationDay;
                        }
                        else if (result_model.VacationExtraType == 2)
                        {
                            usr.VacationExtraChild = (int)result_model.VacationDay;
                            usr2.VacationExtraChild = (int)result_model.VacationDay;
                        }

                    }


                    await _userManager.UpdateAsync(usr2);

                    DateTime work_start_date = usr2.StartWorkDate;

                    if (work_start_date != null)
                    {
                        decimal new_count = 0;
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

                        if (model.CommandDate>= start_interval && model.CommandDate <= end_interval)
                        {
                            var remains = _db.UserVacationRemains.Any(x => x.AppUserId == usr2.Id && x.FromDate == start_interval);
                            var result_remain_model = _db.UserVacationRemains.FirstOrDefault(x => x.AppUserId == usr2.Id && x.FromDate == start_interval);
                            if (!remains)
                            {
                                UserVacationRemain ur = new UserVacationRemain();
                                ur.FromDate = start_interval;
                                ur.ToDate = end_interval;
                                ur.IsDeleted = false;
                                ur.CreatedDate = DateTime.Now;
                                ur.AppUserId = usr2.Id;
                                ur.UsedCount = 0;
                                ur.VacationCount = usr.VacationMainDay + usr.VacationExtraChild + usr.VacationExtraExperience + usr.VacationExtraNature;
                                ur.RemainCount = ur.VacationCount;

                                result_remain_model = await _userVacationRemains.AddReturnEntityAsync(ur);

                            }


                            var personal_contract_chgs = _contractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == usr2.Id && x.Type == PersonalContractConst.VACATION && x.CommandDate >= start_interval && x.CommandDate <= end_interval && x.IsMainVacation).Result;
                            if (personal_contract_chgs.Count() > 0)
                            {
                                DateTime fromDateTmp = start_interval;

                                var main_day = 0;
                                foreach (var el in personal_contract_chgs)
                                {
                                    if (el.CommandDate <= end_interval)
                                    {
                                        double before_day_count = Math.Round((double)((el.CommandDate - fromDateTmp).TotalDays) * el.VacationDay) / 365;
                                        new_count += (int)before_day_count;
                                        fromDateTmp = el.CommandDate;
                                        main_day = (int)el.LastMainVacationDay;
                                    }

                                }

                                double after_day_count = Math.Round((double)((end_interval - fromDateTmp).TotalDays) * main_day) / 365;
                                new_count += (int)after_day_count;
                                new_count += usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                            }
                            else
                            {
                                double after_day_count = Math.Round((double)((end_interval - start_interval).TotalDays) * usr.VacationMainDay) / 365;
                                new_count += (int)after_day_count;
                                new_count += usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild;
                            }
                            result_remain_model.VacationCount = new_count;
                            result_remain_model.RemainCount = result_remain_model.VacationCount - result_remain_model.UsedCount;
                            await _userVacationRemains.UpdateAsync(result_remain_model);
                        }

                    }
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clause = ContractFileReadyConst.personal_change_extra_vacation;
                    var file = new PersonalContractFile();
                    file.PersonalContractId = result_model.Id;
                    file.IsDeleted = false;
                    var clause_result = (await _clauseService.GetAllIncCompAsync(x => x.Key == clause && !x.IsDeleted))[0];
                    file.ClauseId = clause_result.Id;
                    StringBuilder content = await GetDocxContent(clause_result.FilePath, formatKeys);
                    file.FilePath = await AddContractFile(clause_result.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.AddAsync(file);
                }
                return RedirectToAction("List", "Contract");
            }
        }

        [HttpGet]
        [Authorize(Policy = "personalContract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<PersonalContractUpdateDto>(await _contractService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);
            ViewBag.positions = _map.Map<ICollection<PositionListDto>>(await _positionService.GetAllAsync(x => x.IsDeleted  == false && x.DepartmentId == usr.DepartmentId));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.contractFiles = await _contractFileService.GetAllIncCompAsync(x => x.PersonalContractId == id && !x.IsDeleted);
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.clauses = await _clauseService.GetAllAsync(x => !x.IsDeleted && !x.IsBackground);
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "personalContract.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PersonalContractUpdateDto model, IFormFile readyDoc)
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
                var usr2 = await _userManager.FindByIdAsync(model.UserId.ToString());

                if (model.Type == PersonalContractConst.VACATION)
                {
                    if (model.IsMainVacation)
                    {
                        model.NewFullVacationDay = model.VacationDay + usr2.VacationExtraNature + usr2.VacationExtraExperience + usr2.VacationExtraChild;
                        model.NewMainVacationDay = model.VacationDay;
                    }
                    else
                    {
                        model.NewFullVacationDay = model.VacationDay + usr2.VacationMainDay;
                        model.NewMainVacationDay = usr2.VacationMainDay;
                    }
                }
                else if (model.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    model.LastWorkGraphicId = usr2.WorkGraphicId;
                }


                await _contractService.UpdateAsync(_map.Map<PersonalContract>(model));

                var usr = await _userService.FindByUserAllInc(model.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", model.CommandNumber);

                if (model.Type == PersonalContractConst.SALARY)
                {
                    usr.Salary = (double)model.Salary;
                    usr2.Salary = (double)model.Salary;
                    await _userManager.UpdateAsync(usr2);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (model.Type== PersonalContractConst.POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.PositionId = model.PositionId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (model.Type == PersonalContractConst.SALARY_POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.Salary = (double)model.Salary;
                    usr2.PositionId = model.PositionId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (model.Type == PersonalContractConst.WORK_PLACE)
                {
                    formatKeys.Add("workPlace", model.IsMainPlace == true ? "Əsas" : "Əlavə");
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (model.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    formatKeys.Add("workPlace", model.IsMainPlace == true ? "Əsas" : "Əlavə");
                    usr2.WorkGraphicId = (int)model.WorkGraphicId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (model.Type == PersonalContractConst.VACATION)
                {
                    if (model.IsMainVacation)
                    {
                        usr.VacationMainDay = (int)model.VacationDay;
                        usr2.VacationMainDay = (int)model.VacationDay;
                    }
                    else
                    {
                        if (model.VacationExtraType == 0)
                        {
                            usr.VacationExtraExperience = (int)model.VacationDay;
                            usr2.VacationExtraExperience = (int)model.VacationDay;
                        }
                        else if (model.VacationExtraType == 1)
                        {
                            usr.VacationExtraNature = (int)model.VacationDay;
                            usr2.VacationExtraNature = (int)model.VacationDay;
                        }
                        else if (model.VacationExtraType == 2)
                        {
                            usr.VacationExtraChild = (int)model.VacationDay;
                            usr2.VacationExtraChild = (int)model.VacationDay;
                        }

                    }


                    await _userManager.UpdateAsync(usr2);

                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }

                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.PersonalContractId == model.Id && !x.IsDeleted);
                foreach (var el in contract_files)
                {
                    var clause = _clauseService.GetAllIncCompAsync(x => x.Id == el.ClauseId && !x.IsDeleted).Result[0];
                    DeleteFile("wwwroot/contractDocs/", el.FilePath);
                    StringBuilder content = await GetDocxContent(el.Clause.FilePath, formatKeys);
                    el.FilePath = await AddContractFile(el.Clause.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.UpdateAsync(el);
                }
                return RedirectToAction("List", "Contract");
            }
        }

        [Authorize(Policy = "personalContract.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _contractService.FindByIdAsync(id).Result;
            var current = GetSignInUserId();
            if (transactionModel.Type == "VACATION")
            {
                var usr2 = await _userManager.FindByIdAsync(transactionModel.UserId.ToString());
                var work_start_date = usr2.StartWorkDate;
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

                    if (transactionModel.CommandDate >= start_interval && transactionModel.CommandDate <= end_interval)
                    {
                        var personal_contract_chgs = _contractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == usr2.Id && x.Type == PersonalContractConst.VACATION && x.CommandDate >= start_interval && x.CommandDate <= end_interval).Result.OrderBy(x => x.CommandDate).ToList();

                        usr2.VacationMainDay = (int)personal_contract_chgs[0].LastMainVacationDay;
                        if (personal_contract_chgs[0].VacationExtraType == 0)
                        {
                            usr2.VacationExtraExperience = (int)personal_contract_chgs[0].VacationDay;
                        }
                        else if (personal_contract_chgs[0].VacationExtraType == 1)
                        {
                            usr2.VacationExtraNature = (int)personal_contract_chgs[0].VacationDay;
                        }
                        else if (personal_contract_chgs[0].VacationExtraType == 2)
                        {
                            usr2.VacationExtraChild = (int)personal_contract_chgs[0].VacationDay;
                        }
                     
                        await _userManager.UpdateAsync(usr2);

                        foreach (var el in personal_contract_chgs)
                        {
                            var el_del = _contractService.FindByIdAsync(el.Id).Result;
                            el_del.DeleteDate = DateTime.UtcNow.AddHours(4);
                            el_del.DeleteByUserId = current;
                            el_del.IsDeleted = true;
                            await _contractService.UpdateAsync(_map.Map<PersonalContract>(el_del));
                        }

                        var del_list = _vacationContractService.GetAllIncCompAsync(x => x.FromDate >= start_interval).Result;
                        decimal day_count = 0;
                        foreach (var el in del_list)
                        {
                            if (el.VacationType.Key == VacationTypeConst.LABOR)
                            {
                                day_count += el.CalendarDay;
                            }
                            el.DeleteDate = DateTime.UtcNow.AddHours(4);
                            el.DeleteByUserId = current;
                            el.IsDeleted = true;
                            await _vacationContractService.UpdateAsync(_map.Map<VacationContract>(el));
                        }

                        var remain_list = _userVacationRemains.GetAllIncCompAsync(x => x.AppUserId == usr2.Id && !x.IsDeleted).Result.OrderBy(x => x.FromDate);

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
                                await _userVacationRemains.UpdateAsync(el);
                            }
                            else
                            {

                                el.UsedCount -= day_count;
                                el.RemainCount += day_count;
                                await _userVacationRemains.UpdateAsync(el);
                                day_count = 0;
                            }

                            if (day_count == 0)
                            {
                                break;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Cari il üçün məzuniyyət dəyişikliyi silinə bilməz !");
                    }
                }
            }
            else
            {
                transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
                transactionModel.DeleteByUserId = current;
                transactionModel.IsDeleted = true;
                await _contractService.UpdateAsync(_map.Map<PersonalContract>(transactionModel));
            }
            return Ok();
        }
    }
}
