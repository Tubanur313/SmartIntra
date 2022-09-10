using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.PersonalContractDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Web.Controllers.HrControlers
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
        private readonly IDepartmentService _departmentService;
        private readonly INewsService _newsService;
        private readonly ICategoryNewsService _categoryNewsService;
        private readonly IEmailService _emailSender;
        private readonly ICategoryService _categoryService;
        private readonly IUserCompService _userCompService;
        public PersonalContractController(UserManager<IntranetUser> userManager, IntranetContext db, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IUserVacationRemainService userVacationRemains, IMapper mapper, IPersonalContractService contractService, IVacationContractService vacationContractService, IPersonalContractFileService contractFileService, IClauseService clauseService, IContractTypeService contractTypeService, IAppUserService userService, IWorkGraphicService workGraphicService, IPositionService positionService, ICompanyService companyService, IDepartmentService departmentService, INewsService newsService, ICategoryNewsService categoryNewsService, IEmailService emailSender, ICategoryService categoryService, INewsFileService newsFileService, IUserCompService userCompService) : base(userManager, httpContextAccessor, signInManager, mapper)
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
            _departmentService = departmentService;
            _newsService = newsService;
            _categoryNewsService = categoryNewsService;
            _emailSender = emailSender;
            _categoryService = categoryService;
            _userCompService = userCompService;
        }


        [HttpGet]
        [Authorize(Policy = "personalContract.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_userCompService.GetAllIncAsync(GetSignInUserId()).Result.Select(x => x.Company).ToArray());
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
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var usr2 = await _userManager.FindByIdAsync(model.UserId.ToString());
                var add = _map.Map<PersonalContract>(model);
                add.IsDeleted = false;
                add.CreatedDate = DateTime.Now;

                if (add.Type == PersonalContractConst.VACATION)
                {

                    add.LastFullVacationDay = usr2.VacationMainDay + usr2.VacationExtraExperience + usr2.VacationExtraNature
                        + usr2.VacationExtraChild;
                    add.LastMainVacationDay = usr2.VacationMainDay;

                    if (add.IsMainVacation)
                    {
                        add.NewFullVacationDay = add.VacationDay + usr2.VacationExtraExperience + usr2.VacationExtraNature
                        + usr2.VacationExtraChild;
                        add.NewMainVacationDay = add.VacationDay;
                    }
                    else
                    {
                        add.NewMainVacationDay = usr2.VacationMainDay;

                        if (add.VacationExtraType == 0)
                        {
                            add.NewFullVacationDay = add.VacationDay + usr2.VacationMainDay +usr2.VacationExtraNature
                        + usr2.VacationExtraChild;

                        }
                        else if (add.VacationExtraType == 1)
                        {
                            add.NewFullVacationDay = add.VacationDay + usr2.VacationMainDay + usr2.VacationExtraExperience
                         + usr2.VacationExtraChild;
                        }
                        else if (add.VacationExtraType == 2)
                        {
                            add.NewFullVacationDay = add.VacationDay + usr2.VacationMainDay + usr2.VacationExtraNature
                         + usr2.VacationExtraExperience;
                        }

                    }
                }
                else if (add.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    add.LastWorkGraphicId = (int)usr2.WorkGraphicId;
                }
                else if(add.Type == PersonalContractConst.POSITION)
                {
                    add.LastPositionId = usr2.PositionId;
                    add.LastDepartmentId = usr2.DepartmentId;
                }
                else if (add.Type == PersonalContractConst.SALARY)
                {
                    add.LastSalary = usr2.Salary;
                }
                else if (add.Type == PersonalContractConst.SALARY_POSITION)
                {
                    add.LastPositionId = usr2.PositionId;
                    add.LastDepartmentId = usr2.DepartmentId;
                    add.LastSalary = usr2.Salary;
                }
               

                // Emek muqavile senedi
                var current = GetSignInUserId();
                var result_model = _contractService.AddReturnEntityAsync(add).Result;
                var usr = await _userService.FindByUserAllInc(result_model.UserId);

                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                formatKeys.Add("commandDate", result_model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", result_model.CommandNumber);
                formatKeys.Add("contractDate", result_model.CommandDate.ToString("dd.MM.yyyy"));

                if (add.Type == PersonalContractConst.SALARY)
                {
                    usr2.Salary = (double)result_model.Salary;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clauseExtra = ContractFileReadyConst.personal_change_extra_salary;
                    var clauseCommand = ContractFileReadyConst.personal_change_command_salary;
                    var clauseResponsibility = ContractFileReadyConst.recruitment_financial_responsibility;

                    var file_extra = new PersonalContractFile();
                    file_extra.PersonalContractId = result_model.Id;
                    file_extra.IsDeleted = false;

                    var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseExtra && !x.IsDeleted))[0];
                    file_extra.ClauseId = clause_result_extra.Id;
                    StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                    file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                    file_extra.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_extra);

                    var file_command = new PersonalContractFile();
                    file_command.PersonalContractId = result_model.Id;
                    file_command.IsDeleted = false;

                    var clause_result_command = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseCommand && !x.IsDeleted))[0];
                    file_command.ClauseId = clause_result_command.Id;
                    StringBuilder content_command = await GetDocxContent(clause_result_command.FilePath, formatKeys);
                    file_command.FilePath = await AddContractFile(clause_result_command.FilePath, PdfFormatKeys(formatKeys, content_command));
                    file_command.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_command);

                    var file_responsibility = new PersonalContractFile();
                    file_responsibility.PersonalContractId = result_model.Id;
                    file_responsibility.IsDeleted = false;

                    var clause_result_responsibility = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseResponsibility && !x.IsDeleted))[0];
                    file_responsibility.ClauseId = clause_result_responsibility.Id;
                    StringBuilder content_responsibility = await GetDocxContent(clause_result_responsibility.FilePath, formatKeys);
                    file_responsibility.FilePath = await AddContractFile(clause_result_responsibility.FilePath, PdfFormatKeys(formatKeys, content_responsibility));
                    file_responsibility.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_responsibility);
                }
                else if (add.Type== PersonalContractConst.POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.PositionId = result_model.PositionId;
                    usr2.DepartmentId = model.DepartmentId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(model.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clauseExtra = ContractFileReadyConst.personal_change_extra_position;
                    var clauseCommand = ContractFileReadyConst.personal_change_command_position;
                    var clauseResponsibility = ContractFileReadyConst.recruitment_financial_responsibility;

                    var file_extra = new PersonalContractFile();
                    file_extra.PersonalContractId = result_model.Id;
                    file_extra.IsDeleted = false;

                    var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseExtra && !x.IsDeleted))[0];
                    file_extra.ClauseId = clause_result_extra.Id;
                    StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                    file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                    file_extra.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_extra);

                    var file_command = new PersonalContractFile();
                    file_command.PersonalContractId = result_model.Id;
                    file_command.IsDeleted = false;

                    var clause_result_command = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseCommand && !x.IsDeleted))[0];
                    file_command.ClauseId = clause_result_command.Id;
                    StringBuilder content_command = await GetDocxContent(clause_result_command.FilePath, formatKeys);
                    file_command.FilePath = await AddContractFile(clause_result_command.FilePath, PdfFormatKeys(formatKeys, content_command));
                    file_command.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_command);

                    var file_responsibility = new PersonalContractFile();
                    file_responsibility.PersonalContractId = result_model.Id;
                    file_responsibility.IsDeleted = false;

                    var clause_result_responsibility = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseResponsibility && !x.IsDeleted))[0];
                    file_responsibility.ClauseId = clause_result_responsibility.Id;
                    StringBuilder content_responsibility = await GetDocxContent(clause_result_responsibility.FilePath, formatKeys);
                    file_responsibility.FilePath = await AddContractFile(clause_result_responsibility.FilePath, PdfFormatKeys(formatKeys, content_responsibility));
                    file_responsibility.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_responsibility);
                }
                else if (add.Type == PersonalContractConst.SALARY_POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.Salary = (double)result_model.Salary;
                    usr2.PositionId = result_model.PositionId;
                    usr2.DepartmentId = model.DepartmentId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(add.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var clauseExtra = ContractFileReadyConst.personal_change_extra_salary_position;
                    var clauseCommand = ContractFileReadyConst.personal_change_command_salary_position;
                    var clauseResponsibility = ContractFileReadyConst.recruitment_financial_responsibility;

                    var file_extra = new PersonalContractFile();
                    file_extra.PersonalContractId = result_model.Id;
                    file_extra.IsDeleted = false;

                    var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseExtra && !x.IsDeleted))[0];
                    file_extra.ClauseId = clause_result_extra.Id;
                    StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                    file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                    file_extra.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_extra);

                    var file_command = new PersonalContractFile();
                    file_command.PersonalContractId = result_model.Id;
                    file_command.IsDeleted = false;

                    var clause_result_command = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseCommand && !x.IsDeleted))[0];
                    file_command.ClauseId = clause_result_command.Id;
                    StringBuilder content_command = await GetDocxContent(clause_result_command.FilePath, formatKeys);
                    file_command.FilePath = await AddContractFile(clause_result_command.FilePath, PdfFormatKeys(formatKeys, content_command));
                    file_command.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_command);

                    var file_responsibility = new PersonalContractFile();
                    file_responsibility.PersonalContractId = result_model.Id;
                    file_responsibility.IsDeleted = false;

                    var clause_result_responsibility = (await _clauseService.GetAllIncCompAsync(x => x.Key == clauseResponsibility && !x.IsDeleted))[0];
                    file_responsibility.ClauseId = clause_result_responsibility.Id;
                    StringBuilder content_responsibility = await GetDocxContent(clause_result_responsibility.FilePath, formatKeys);
                    file_responsibility.FilePath = await AddContractFile(clause_result_responsibility.FilePath, PdfFormatKeys(formatKeys, content_responsibility));
                    file_responsibility.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file_responsibility);
                }
                else if (add.Type == PersonalContractConst.WORK_PLACE)
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
                    file.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file);
                }
                else if (add.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    formatKeys.Add("workPlace", result_model.IsMainPlace ? "Əsas" : "Əlavə");
                    usr2.WorkGraphicId = result_model.WorkGraphicId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(add.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);

                    var file = new PersonalContractFile();
                    file.PersonalContractId = result_model.Id;
                    file.IsDeleted = false;
                    var clause_result = (await _clauseService.GetAllIncCompAsync(x => x.Id == result_model.ClauseId && !x.IsDeleted))[0];
                    file.ClauseId = clause_result.Id;
                    StringBuilder content = await GetDocxContent(clause_result.FilePath, formatKeys);
                    file.FilePath = await AddContractFile(clause_result.FilePath, PdfFormatKeys(formatKeys, content));
                    file.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file);
                }
                else if (add.Type == PersonalContractConst.VACATION)
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
                        }
                        else if (result_model.VacationExtraType == 1)
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
                        if (((DateTime)add.CommandDate).Month > work_start_date.Month || (((DateTime)add.CommandDate).Month == work_start_date.Month && ((DateTime)add.CommandDate).Day >= work_start_date.Day))
                        {
                            start_interval = new DateTime(((DateTime)add.CommandDate).Year, work_start_date.Month, work_start_date.Day);
                            end_interval = new DateTime(((DateTime)add.CommandDate).Year + 1, work_start_date.Month, work_start_date.Day);
                        }
                        else
                        {
                            start_interval = new DateTime(((DateTime)add.CommandDate).Year - 1, work_start_date.Month, work_start_date.Day);
                            end_interval = new DateTime(((DateTime)add.CommandDate).Year, work_start_date.Month, work_start_date.Day);
                        }

                        if (add.CommandDate>= start_interval && add.CommandDate <= end_interval)
                        {
                            var remains = _db.UserVacationRemains.Any(x => x.AppUserId == usr2.Id && !x.IsDeleted && x.FromDate == start_interval);
                            var result_remain_model = _db.UserVacationRemains.FirstOrDefault(x => x.AppUserId == usr2.Id && !x.IsDeleted && x.FromDate == start_interval);
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
                                        double before_day_count = Math.Round((double)((el.CommandDate - fromDateTmp).TotalDays) * (int)el.LastMainVacationDay) / 365;
                                        new_count += (int)before_day_count;
                                        fromDateTmp = el.CommandDate;
                                        main_day = (int)el.VacationDay;
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

                            usr2.VacationTotal = 0;
                            var all_remains = _db.UserVacationRemains.Where(x => x.AppUserId == usr2.Id && !x.IsDeleted);
                            foreach (var itm in all_remains)
                            {
                                usr2.VacationTotal += itm.RemainCount;
                            }
                            await _userManager.UpdateAsync(usr2);
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
                    file.CreatedDate = DateTime.Now;
                    await _contractFileService.AddAsync(file);
                }

                if (model.SendNews)
                {   
                    var userC = await _userService.FindByUserAllInc(model.UserId);
                    var gender = userC.Gender == "MALE" ? "bəy" : "xanım";
                    var news = new News
                    {
                        Title = "Vəzifə Dəyişikliyi",
                        Description = "Hörmətli həmkarlar." +
                                      $"\r\nNəzərinizə çatdırmaq istərdim ki, {userC.Fullname} artıq {userC.Company.Name} şirkətdə {userC.Position.Name} olaraq fəaliyyətinə davam edəcəkdir. " +
                                      $"\r\n{userC.Name}"+" "+ $"{gender}" +
                                      ", yeni pozisiyanızda Sizə uğurlar diləyirik!",
                        AppUserId = null,
                        CreatedByUserId = current,
                        CreatedDate = DateTime.Now
                    };
                    var newsResult = await _newsService.AddReturnEntityAsync(news);
                    var newsCategoryId = await _categoryService
                        .GetAsync(x => x.Name == "Məlumat"
                                       || x.Name == "Melumat"
                                       || x.Name == "Malumat");
                    //var newsFile = new NewsFile
                    //{
                    //    Name = userC.Picture,
                    //    NewsId = newsResult.Id,
                    //    CreatedByUserId = current,
                    //    CreatedDate = DateTime.Now
                    //};
                    var categoryNews = new CategoryNews
                    {
                        NewsId = newsResult.Id,
                        CategoryId = newsCategoryId.Id,
                        CreatedByUserId = current,
                        CreatedDate = DateTime.Now
                    };
                    //await _newsFileService.AddAsync(newsFile);
                    await _categoryNewsService.AddAsync(categoryNews);
                };
                if (model.SendMail)
                {
                    var userC = await _userService.FindByUserAllInc(model.UserId);
                    var gender = userC.Gender == "MALE" ? "bəy" : "xanım";
                    _emailSender.ContactChangeSendEmail(userC.Fullname, usr.Name, gender, userC.Company.Name, usr.Position.Name);
                }
                return RedirectToAction("List", "Contract");
            }
        }

        [HttpGet]
        [Authorize(Policy = "personalContract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<PersonalContractUpdateDto>(await _contractService.FindByIdAsync(id));
            if (listModel.PositionId != null)
            {
                var position = await _positionService.FindByIdAsync((int)listModel.PositionId);
                listModel.DepartmentId = position.DepartmentId;
            }
               
            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);
            ViewBag.positions = _map.Map<ICollection<PositionListDto>>(await _positionService.GetAllAsync(x => x.IsDeleted  == false && x.DepartmentId == listModel.DepartmentId));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.contractFiles = await _contractFileService.GetAllIncCompAsync(x => x.PersonalContractId == id && !x.IsDeleted);
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.clauses = await _clauseService.GetAllAsync(x => !x.IsDeleted && !x.IsBackground);
            ViewBag.departments = _map.Map<ICollection<DepartmentListDto>>(
                await _departmentService.GetAllAsync(x => x.IsDeleted  == false && x.CompanyId == usr.CompanyId));
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "personalContract.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PersonalContractUpdateDto model, IFormFile readyDoc)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List", "Contract");
            }
            else
            {
                var data = await _contractService.FindByIdAsync(model.Id);
                var current = GetSignInUserId();
                var update = _map.Map<PersonalContract>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                var usr2 = await _userManager.FindByIdAsync(update.UserId.ToString());

                if (update.Type == PersonalContractConst.VACATION)
                {
                    if (update.IsMainVacation)
                    {
                        update.NewFullVacationDay = update.VacationDay + usr2.VacationExtraNature + usr2.VacationExtraExperience + usr2.VacationExtraChild;
                        update.NewMainVacationDay = update.VacationDay;
                    }
                    else
                    {

                        update.NewMainVacationDay = usr2.VacationMainDay;
                        if (update.VacationExtraType == 0)
                        {
                            update.NewFullVacationDay = update.VacationDay + usr2.VacationMainDay + usr2.VacationExtraNature
                        + usr2.VacationExtraChild;

                        }
                        else if (update.VacationExtraType == 1)
                        {
                            update.NewFullVacationDay = update.VacationDay + usr2.VacationMainDay + usr2.VacationExtraExperience
                         + usr2.VacationExtraChild;
                        }
                        else if (update.VacationExtraType == 2)
                        {
                            update.NewFullVacationDay = update.VacationDay + usr2.VacationMainDay + usr2.VacationExtraNature
                         + usr2.VacationExtraExperience;
                        }

                    }
                }
                //else if (update.Type == PersonalContractConst.WORK_GRAPHIC)
                //{
                //    update.LastWorkGraphicId = (int)usr2.WorkGraphicId;
                //}


                await _contractService.UpdateAsync(update);

                var usr = await _userService.FindByUserAllInc(update.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                formatKeys.Add("commandDate", update.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", update.CommandNumber);
                formatKeys.Add("contractDate", update.CommandDate.ToString("dd.MM.yyyy"));

                if (update.Type == PersonalContractConst.SALARY)
                {
                    usr.Salary = (double)update.Salary;
                    usr2.Salary = (double)update.Salary;
                    await _userManager.UpdateAsync(usr2);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (update.Type== PersonalContractConst.POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.PositionId = update.PositionId;
                    usr2.DepartmentId = model.DepartmentId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(update.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (update.Type == PersonalContractConst.SALARY_POSITION)
                {
                    formatKeys.Add("oldPosition", usr.Position.Name);
                    usr2.Salary = (double)update.Salary;
                    usr2.PositionId = update.PositionId;
                    usr2.DepartmentId = model.DepartmentId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(update.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (update.Type == PersonalContractConst.WORK_PLACE)
                {
                    formatKeys.Add("workPlace", update.IsMainPlace == true ? "Əsas" : "Əlavə");
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (update.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    formatKeys.Add("workPlace", update.IsMainPlace == true ? "Əsas" : "Əlavə");
                    usr2.WorkGraphicId = (int)update.WorkGraphicId;
                    await _userManager.UpdateAsync(usr2);
                    usr = await _userService.FindByUserAllInc(update.UserId);
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }
                else if (update.Type == PersonalContractConst.VACATION)
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

                    DateTime work_start_date = usr2.StartWorkDate;

                    if (work_start_date != null)
                    {
                        decimal new_count = 0;
                        DateTime start_interval;
                        DateTime end_interval;
                        if (model.CommandDate.Month > work_start_date.Month || (model.CommandDate.Month == work_start_date.Month && DateTime.Now.Day >= work_start_date.Day))
                        {
                            start_interval = new DateTime(model.CommandDate.Year, work_start_date.Month, work_start_date.Day);
                            end_interval = new DateTime(model.CommandDate.Year + 1, work_start_date.Month, work_start_date.Day);
                        }
                        else
                        {
                            start_interval = new DateTime(model.CommandDate.Year - 1, work_start_date.Month, work_start_date.Day);
                            end_interval = new DateTime(model.CommandDate.Year, work_start_date.Month, work_start_date.Day);
                        }

                        if (model.CommandDate >= start_interval && model.CommandDate <= end_interval)
                        {
                            var remains = _db.UserVacationRemains.Any(x => x.AppUserId == usr2.Id && !x.IsDeleted && x.FromDate == start_interval);
                            var result_remain_model = _db.UserVacationRemains.FirstOrDefault(x => x.AppUserId == usr2.Id && !x.IsDeleted && x.FromDate == start_interval);
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
                                        double before_day_count = Math.Round((double)((el.CommandDate - fromDateTmp).TotalDays) * (int)el.LastMainVacationDay) / 365;
                                        new_count += (int)before_day_count;
                                        fromDateTmp = el.CommandDate;
                                        main_day = (int)el.VacationDay;
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

                            usr2.VacationTotal = 0;
                            var all_remains = _db.UserVacationRemains.Where(x => x.AppUserId == usr2.Id && !x.IsDeleted);
                            foreach (var itm in all_remains)
                            {
                                usr2.VacationTotal += itm.RemainCount;
                            }
                            await _userManager.UpdateAsync(usr2);
                        }

                    }
                    formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                }

                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.PersonalContractId == update.Id && !x.IsDeleted);
                foreach (var el in contract_files)
                {
                    var clause = _clauseService.GetAllIncCompAsync(x => x.Id == el.ClauseId && !x.IsDeleted).Result[0];
                    DeleteFile("wwwroot/contractDocs/", el.FilePath);
                    StringBuilder content = await GetDocxContent(el.Clause.FilePath, formatKeys);
                    el.FilePath = await AddContractFile(el.Clause.FilePath, PdfFormatKeys(formatKeys, content));
                    await _contractFileService.UpdateAsync(el);
                }
                return RedirectToAction("List", "Contract", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "personalContract.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _contractService.FindByIdAsync(id).Result;
            var current = GetSignInUserId();
            var usr2 = await _userManager.FindByIdAsync(transactionModel.UserId.ToString());

            if (transactionModel.Type == "VACATION")
            {
              
                usr2.VacationMainDay = (int)transactionModel.LastMainVacationDay;
                if (!transactionModel.IsMainVacation)
                {
                    var diff = (int)transactionModel.NewFullVacationDay - (int)transactionModel.LastFullVacationDay;
                    if (transactionModel.VacationExtraType == 0)
                    {
                        usr2.VacationExtraExperience = (int)transactionModel.VacationDay - diff;
                    }
                    else if (transactionModel.VacationExtraType == 1)
                    {
                        usr2.VacationExtraNature = (int)transactionModel.VacationDay - diff;
                    }
                    else if (transactionModel.VacationExtraType == 2)
                    {
                        usr2.VacationExtraChild = (int)transactionModel.VacationDay - diff;
                    }
                }

                await _userManager.UpdateAsync(usr2);

                transactionModel.DeleteDate = DateTime.Now;
                transactionModel.DeleteByUserId = current;
                transactionModel.IsDeleted = true;
                await _contractService.UpdateAsync(_map.Map<PersonalContract>(transactionModel));

                DateTime work_start_date = usr2.StartWorkDate;

                if (work_start_date != null)
                {
                    decimal new_count = 0;
                    DateTime start_interval;
                    DateTime end_interval;
                    if (((DateTime)transactionModel.CommandDate).Month > work_start_date.Month || (((DateTime)transactionModel.CommandDate).Month == work_start_date.Month && ((DateTime)transactionModel.CommandDate).Day >= work_start_date.Day))
                    {
                        start_interval = new DateTime(((DateTime)transactionModel.CommandDate).Year, work_start_date.Month, work_start_date.Day);
                        end_interval = new DateTime(((DateTime)transactionModel.CommandDate).Year + 1, work_start_date.Month, work_start_date.Day);
                    }
                    else
                    {
                        start_interval = new DateTime(((DateTime)transactionModel.CommandDate).Year - 1, work_start_date.Month, work_start_date.Day);
                        end_interval = new DateTime(((DateTime)transactionModel.CommandDate).Year, work_start_date.Month, work_start_date.Day);
                    }

                    if (transactionModel.CommandDate >= start_interval && transactionModel.CommandDate <= end_interval)
                    {
                        var remains = _db.UserVacationRemains.Any(x => x.AppUserId == usr2.Id && !x.IsDeleted && x.FromDate == start_interval);
                        var result_remain_model = _db.UserVacationRemains.FirstOrDefault(x => x.AppUserId == usr2.Id && !x.IsDeleted && x.FromDate == start_interval);
                        if (!remains)
                        {
                            UserVacationRemain ur = new UserVacationRemain();
                            ur.FromDate = start_interval;
                            ur.ToDate = end_interval;
                            ur.IsDeleted = false;
                            ur.CreatedDate = DateTime.Now;
                            ur.AppUserId = usr2.Id;
                            ur.UsedCount = 0;
                            ur.VacationCount = usr2.VacationMainDay + usr2.VacationExtraChild + usr2.VacationExtraExperience + usr2.VacationExtraNature;
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
                                    double before_day_count = Math.Round((double)((el.CommandDate - fromDateTmp).TotalDays) * (int)el.LastMainVacationDay) / 365;
                                    new_count += (int)before_day_count;
                                    fromDateTmp = el.CommandDate;
                                    main_day = (int)el.VacationDay;
                                }

                            }

                            double after_day_count = Math.Round((double)((end_interval - fromDateTmp).TotalDays) * main_day) / 365;
                            new_count += (int)after_day_count;
                            new_count += usr2.VacationExtraNature + usr2.VacationExtraExperience + usr2.VacationExtraChild;
                        }
                        else
                        {
                            double after_day_count = Math.Round((double)((end_interval - start_interval).TotalDays) * usr2.VacationMainDay) / 365;
                            new_count += (int)after_day_count;
                            new_count += usr2.VacationExtraNature + usr2.VacationExtraExperience + usr2.VacationExtraChild;
                        }
                        result_remain_model.VacationCount = new_count;
                        result_remain_model.RemainCount = result_remain_model.VacationCount - result_remain_model.UsedCount;
                        await _userVacationRemains.UpdateAsync(result_remain_model);

                        usr2.VacationTotal = 0;
                        var all_remains = _db.UserVacationRemains.Where(x => x.AppUserId == usr2.Id && !x.IsDeleted);
                        foreach (var itm in all_remains)
                        {
                            usr2.VacationTotal += itm.RemainCount;
                        }
                        await _userManager.UpdateAsync(usr2);
                    }
                }
            }
            else
            {
                 if (transactionModel.Type == PersonalContractConst.POSITION)
                {
                    usr2.PositionId = transactionModel.LastPositionId;
                    usr2.DepartmentId = transactionModel.LastDepartmentId;
                }
                else if (transactionModel.Type == PersonalContractConst.SALARY)
                {
                    usr2.Salary = transactionModel.LastSalary;
                }
                else if (transactionModel.Type == PersonalContractConst.SALARY_POSITION)
                {
                    usr2.PositionId = transactionModel.LastPositionId;
                    usr2.DepartmentId = transactionModel.LastDepartmentId;
                    usr2.Salary = transactionModel.LastSalary;
                }
                else if (transactionModel.Type == PersonalContractConst.WORK_GRAPHIC)
                {
                    usr2.WorkGraphicId = transactionModel.LastWorkGraphicId;
                }
                await _userManager.UpdateAsync(usr2);

                transactionModel.DeleteDate = DateTime.Now;
                transactionModel.DeleteByUserId = current;
                transactionModel.IsDeleted = true;
                await _contractService.UpdateAsync(_map.Map<PersonalContract>(transactionModel));
            }  
        }
    }
}
