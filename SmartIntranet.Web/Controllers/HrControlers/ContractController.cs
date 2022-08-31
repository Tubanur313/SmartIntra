using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Entities.Concrete.Intranet;
using NPOI.SS.Formula.Functions;
using SmartIntranet.Entities.Concrete.IntraHr;


namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class ContractController : BaseIdentityController
    {
        private readonly IUserCompService _userCompService;
        private readonly IContractService _contractService;
        private readonly IPersonalContractService _personalContractService;
        private readonly ITerminationContractService _terminationContractService;
        private readonly IVacationContractService _vacationContractService;
        private readonly IContractFileService _contractFileService;
        private readonly IContractTypeService _contractTypeService;
        private readonly IClauseService _clauseService;
        private readonly IAppUserService _userService;
        private readonly IWorkGraphicService _workGraphicService;
        private readonly ICompanyService _companyService;
        private readonly IAppUserService _appUserService;
        private readonly IBusinessTripService _businessTripService;
        private readonly ILongContractService _longContractService;
        private readonly ICategoryService _categoryService;
        private readonly INewsFileService _newsFileService;
        private readonly INewsService _newsService;
        private readonly ICategoryNewsService _categoryNewsService;
        private readonly IEmailService _emailSender;


        public ContractController(UserManager<IntranetUser> userManager, IAppUserService appUserService,
            IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager,
            ITerminationContractService terminationContractService, IMapper mapper,
            IContractService contractService, IPersonalContractService personalContractService,
            IContractFileService contractFileService, IClauseService clauseService,
            IContractTypeService contractTypeService, IVacationContractService vacationContractService,
            IAppUserService userService, IWorkGraphicService workGraphicService,
            ICompanyService companyService, ILongContractService longContractService,
            IUserCompService userCompService,
            IBusinessTripService businessTripService, ICategoryService categoryService, INewsFileService newsFileService, INewsService newsService, ICategoryNewsService categoryNewsService, IEmailService emailSender) : base(userManager, httpContextAccessor, signInManager, mapper)
        {

            _contractService = contractService;
            _personalContractService = personalContractService;
            _terminationContractService = terminationContractService;
            _vacationContractService = vacationContractService;
            _contractTypeService = contractTypeService;
            _contractFileService = contractFileService;
            _longContractService = longContractService;
            _userCompService = userCompService;
            _userService = userService;
            _clauseService = clauseService;
            _workGraphicService = workGraphicService;
            _companyService = companyService;
            _appUserService = appUserService;
            _businessTripService = businessTripService;
            _categoryService = categoryService;
            _newsFileService = newsFileService;
            _newsService = newsService;
            _categoryNewsService = categoryNewsService;
            _emailSender = emailSender;
        }

        [Authorize(Policy = "contract.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            ViewBag.contractTypes = await _contractTypeService.GetAllAsync(x => !x.IsDeleted);
            List<ContractListDto> result_list = new List<ContractListDto>();
            var userComp = await _userCompService.FirstOrDefault(GetSignInUserId());
            ViewBag.CompId = userComp.CompanyId;
            var contracts = _map.Map<List<ContractListDto>>(await _contractService
                .GetAllIncCompAsync());

            var work_accept = "WORK_ACCEPT";
            var el_work_accept = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == work_accept).Result[0].Name;
            foreach (var el in contracts)
            {
                el.ContractKey = work_accept;
                el.ContractName = el_work_accept;
                result_list.Add(el);
            }

            var personal_contracts = _map.Map<List<ContractListDto>>(await _personalContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var personal_chg = "PERSONAL_CHG";
            var el_personal_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == personal_chg).Result[0].Name;
            foreach (var el in personal_contracts)
            {
                el.ContractKey = personal_chg;
                el.ContractName = el_personal_chg;
                result_list.Add(el);
            }


            var vacation_contracts = _map.Map<List<ContractListDto>>(await _vacationContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var vacation_chg = "VACATION";
            var el_vacation_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == vacation_chg).Result[0].Name;
            foreach (var el in vacation_contracts)
            {
                el.ContractKey = vacation_chg;
                el.ContractName = el_vacation_chg;
                result_list.Add(el);
            }

            if (userComp.CompanyId > 0)
            {
                var business_trips_org = await _businessTripService.GetAllIncAsync(x => !x.IsDeleted && x.CompanyId == userComp.CompanyId);
                var business_trips = _map.Map<List<ContractListDto>>(business_trips_org);
                var business_trip = "BUSINESS_TRIP";
                var el_business_trip = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == business_trip).Result[0].Name;
                foreach (var el in business_trips)
                {
                    int id = el.BusinessTripUsers.FirstOrDefault().UserId;
                    IntranetUser user = await _appUserService.FindByUserAllInc(id);
                    el.FullName = el.BusinessTripUsers.Count > 1 ? "Multi" : $"{user.Name} {user.Surname} / {user.Position.Company.Name} / {user.Position.Department.Name} / {user.Position.Name}";
                    el.ContractKey = business_trip;
                    el.ContractName = el_business_trip;
                    result_list.Add(el);
                }
            }
            else
            {
                var business_trips_org = await _businessTripService.GetAllIncAsync(x => !x.IsDeleted);
                var business_trips = _map.Map<List<ContractListDto>>(business_trips_org);
                var business_trip = "BUSINESS_TRIP";
                var el_business_trip = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == business_trip).Result[0].Name;
                foreach (var el in business_trips)
                {
                    int id = el.BusinessTripUsers.FirstOrDefault().UserId;
                    IntranetUser user = await _appUserService.FindByUserAllInc(id);
                    el.FullName = el.BusinessTripUsers.Count > 1 ? "Multi" : $"{user.Name} {user.Surname} / {user.Position.Company.Name} / {user.Position.Department.Name} / {user.Position.Name}";
                    el.ContractKey = business_trip;
                    el.ContractName = el_business_trip;
                    result_list.Add(el);
                }
            }



            var termination_contracts = _map.Map<List<ContractListDto>>(await _terminationContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var termination_chg = "TERMINATION";
            var el_termination_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == termination_chg).Result[0].Name;
            foreach (var el in termination_contracts)
            {
                el.ContractKey = termination_chg;
                el.ContractName = el_termination_chg;
                result_list.Add(el);
            }

            var long_contracts = _map.Map<List<ContractListDto>>(await _longContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var long_chg = "LONG_CONTRACT";
            var el_long_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == long_chg).Result[0].Name;
            foreach (var el in long_contracts)
            {
                el.ContractKey = long_chg;
                el.ContractName = el_long_chg;
                result_list.Add(el);
            }

            if (userComp.CompanyId.Equals(null))
            {
                return View(new List<ContractListDto>());
            }





            if (!result_list.Any()) return View(new List<ContractListDto>());
            {
                List<ContractListDto> model_result_list = new List<ContractListDto>();
                var multi = result_list.Where(x => x.FullName == "Multi").ToList();
                var contract = result_list.Where(x => x.FullName != "Multi"
                                                      && x.User.CompanyId == userComp.CompanyId).ToList();
                TempData["success"] = success;
                TempData["error"] = error;
                if (multi.Count > 0)
                {
                    multi.ForEach(x => model_result_list.Add(x));
                }

                if (contract.Count > 0)
                {
                    contract.ForEach(x => model_result_list.Add(x));
                }
                return View(model_result_list
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate
                    ).ToList());
            }
        }

        [HttpPost]
        [Authorize(Policy = "contract.list")]
        public async Task<IActionResult> List(int CompId, int DepartId, int PositId, string Interval, string DocumentType)
        {
            ViewBag.contractTypes = await _contractTypeService.GetAllAsync(x => !x.IsDeleted);
            List<ContractListDto> result_list = new List<ContractListDto>();


            var contracts = _map.Map<List<ContractListDto>>(await _contractService
                .GetAllIncCompAsync(CompId, DepartId, PositId, Interval));


            var work_accept = "WORK_ACCEPT";
            var el_work_accept = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == work_accept).Result[0].Name;
            foreach (var el in contracts)
            {
                el.ContractKey = work_accept;
                el.ContractName = el_work_accept;
                result_list.Add(el);
            }

            var personal_contracts = _map.Map<List<ContractListDto>>(await _personalContractService
                .GetAllIncCompAsync(x => !x.IsDeleted
                //&& x.User.CompanyId == CompId
                //&& x.User.DepartmentId == DepartId
                //&& x.User.PositionId == PositId
                ));
            var personal_chg = "PERSONAL_CHG";
            var el_personal_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == personal_chg).Result[0].Name;
            foreach (var el in personal_contracts)
            {
                el.ContractKey = personal_chg;
                el.ContractName = el_personal_chg;
                result_list.Add(el);
            }


            var vacation_contracts = _map.Map<List<ContractListDto>>(await _vacationContractService
                .GetAllIncCompAsync(x => !x.IsDeleted
                //&& x.User.CompanyId == CompId
                //&& x.User.DepartmentId == DepartId
                //&& x.User.PositionId == PositId
                ));
            var vacation_chg = "VACATION";
            var el_vacation_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == vacation_chg).Result[0].Name;
            foreach (var el in vacation_contracts)
            {
                el.ContractKey = vacation_chg;
                el.ContractName = el_vacation_chg;
                result_list.Add(el);
            }

            if (CompId>0)
            {
                var business_trips_org = await _businessTripService.GetAllIncAsync(x => !x.IsDeleted && x.CompanyId==CompId);
                var business_trips = _map.Map<List<ContractListDto>>(business_trips_org);
                var business_trip = "BUSINESS_TRIP";
                var el_business_trip = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == business_trip).Result[0].Name;
                foreach (var el in business_trips)
                {
                    int id = el.BusinessTripUsers.FirstOrDefault().UserId;
                    IntranetUser user = await _appUserService.FindByUserAllInc(id);
                    el.FullName = el.BusinessTripUsers.Count > 1 ? "Multi" : $"{user.Name} {user.Surname} / {user.Position.Company.Name} / {user.Position.Department.Name} / {user.Position.Name}";
                    el.ContractKey = business_trip;
                    el.ContractName = el_business_trip;
                    result_list.Add(el);
                }
            }
            else
            {
                var business_trips_org = await _businessTripService.GetAllIncAsync(x => !x.IsDeleted);
                var business_trips = _map.Map<List<ContractListDto>>(business_trips_org);
                var business_trip = "BUSINESS_TRIP";
                var el_business_trip = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == business_trip).Result[0].Name;
                foreach (var el in business_trips)
                {
                    int id = el.BusinessTripUsers.FirstOrDefault().UserId;
                    IntranetUser user = await _appUserService.FindByUserAllInc(id);
                    el.FullName = el.BusinessTripUsers.Count > 1 ? "Multi" : $"{user.Name} {user.Surname} / {user.Position.Company.Name} / {user.Position.Department.Name} / {user.Position.Name}";
                    el.ContractKey = business_trip;
                    el.ContractName = el_business_trip;
                    result_list.Add(el);
                }
            }



            var termination_contracts = _map.Map<List<ContractListDto>>(await _terminationContractService
                .GetAllIncCompAsync(x => !x.IsDeleted
                //&& x.User.CompanyId == CompId
                //&& x.User.DepartmentId == DepartId
                //&& x.User.PositionId == PositId
                ));
            var termination_chg = "TERMINATION";
            var el_termination_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == termination_chg).Result[0].Name;
            foreach (var el in termination_contracts)
            {
                el.ContractKey = termination_chg;
                el.ContractName = el_termination_chg;
                result_list.Add(el);
            }

            var long_contracts = _map.Map<List<ContractListDto>>(await _longContractService
                .GetAllIncCompAsync(x => !x.IsDeleted
                //&& x.User.CompanyId == CompId
                //&& x.User.DepartmentId == DepartId
                //&& x.User.PositionId == PositId
                ));
            var long_chg = "LONG_CONTRACT";
            var el_long_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == long_chg).Result[0].Name;
            foreach (var el in long_contracts)
            {
                el.ContractKey = long_chg;
                el.ContractName = el_long_chg;
                result_list.Add(el);
            }

            var multi = result_list.Where(x => x.FullName == "Multi").ToList();
            result_list = result_list
                    .Where(x => x.FullName != "Multi").ToList();


            if (Interval is null && DocumentType != null)
            {
                if (CompId > 0 && PositId == 0 && DepartId == 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                         && s.ContractKey == DocumentType).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
                }
                else if (CompId > 0 && DepartId > 0 && PositId == 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                         && s.User.DepartmentId == DepartId &&
                                                         s.ContractKey == DocumentType).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
                }
                else if (CompId > 0 && DepartId > 0 && PositId > 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                         && s.User.DepartmentId == DepartId
                                                         && s.User.PositionId == PositId
                                                         && s.ContractKey == DocumentType
                    ).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
                }
                else
                {
                    result_list = result_list.Where(s => s.ContractKey == DocumentType).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
            }
            else if (Interval != null && DocumentType != null)
            {
                if (CompId > 0 && PositId == 0 && DepartId == 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                         && s.ContractKey == DocumentType).ToList();
                    if (multi.Count > 0 && multi.Any(r=>r.ContractKey== DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
                else if (CompId > 0 && DepartId > 0 && PositId == 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                    && s.User.DepartmentId == DepartId && s.ContractKey == DocumentType).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
                else if (CompId > 0 && DepartId > 0 && PositId > 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                          && s.User.DepartmentId == DepartId
                                                          && s.User.PositionId == PositId
                                                          && s.ContractKey == DocumentType
                    ).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
                else
                {
                    result_list = result_list.Where(s => s.ContractKey == DocumentType).ToList();
                    if (multi.Count > 0 && multi.Any(r => r.ContractKey == DocumentType))
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
            }
            else
            {
                if (CompId > 0 && PositId == 0 && DepartId == 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId).ToList();
                    if (multi.Count > 0)
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
                else if (CompId > 0 && DepartId > 0 && PositId == 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                         && s.User.DepartmentId == DepartId).ToList();
                    if (multi.Count > 0)
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
                else if (CompId > 0 && DepartId > 0 && PositId > 0)
                {
                    result_list = result_list.Where(s => s.User.CompanyId == CompId
                                                         && s.User.DepartmentId == DepartId
                                                         && s.User.PositionId == PositId
                    ).ToList();
                    if (multi.Count > 0)
                    {
                        multi.ForEach(x => result_list.Add(x));
                    }
                    return View(result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());

                }
                else
                {
                    return View(new List<ContractListDto>());
                }
            }
        }

        [HttpGet]
        [Authorize(Policy = "contract.detail")]
        public async Task<IActionResult> Detail()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "contract.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_userCompService.GetAllIncAsync(GetSignInUserId()).Result.Select(x => x.Company).ToArray());
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.clauses = await _clauseService.GetAllAsync(x => !x.IsDeleted && !x.IsBackground);
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "contract.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ContractAddDto model, IFormFile readyDoc)
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
                var current = GetSignInUserId();
                var result_model = _contractService.AddReturnEntityAsync(_map.Map<Contract>(model)).Result;

                // Keys formats
                var usr = await _appUserService.FindByUserAllInc(result_model.UserId);
                var usr2 = await _userManager.FindByIdAsync(model.UserId.ToString());
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();
                formatKeys.Add("contractDate", result_model.ContractStart.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                formatKeys.Add("contractDatePlus", model.ContractStart.AddYears(1).ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                if (result_model.ContractEnd != null)
                    formatKeys.Add("contractDateEnd", result_model.ContractEnd?.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                if (result_model.HasTerm)
                {
                    var range = result_model.ContractStart.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")) + " tarixindən " + result_model.ContractEnd?.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")) + " tarixinədək ";
                    formatKeys.Add("contractDateRange", range);
                }
                else
                {
                    formatKeys.Add("contractDateRange", " müddətsiz ");
                }
                formatKeys.Add("contractNumber", result_model.ContractNumber);
                formatKeys.Add("commandNumber", model.CommandNumber);
                formatKeys.Add("commandDate", result_model.CommandDate.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                formatKeys.Add("isAlternate", result_model.IsAlternate ? "növbəli" : "növbəsiz");
                formatKeys.Add("byTransport", result_model.ByTransport ? "edilir" : "edilmir");
                formatKeys.Add("hasTerm", result_model.HasTerm ? "li" : "siz");

                usr2.WorkGraphicId = model.WorkGraphicId;
                await _userManager.UpdateAsync(usr2);
                usr = await _userService.FindByUserAllInc(model.UserId);

                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                //

                // Emek muqavile senedi
                var contractFile = new ContractFile
                {
                    ContractId = result_model.Id,
                    IsDeleted = false,
                    IsClause = model.ContractFileType == ContractConst.TEMPLATE ? true : false
                };
                contractFile.ClauseId = contractFile.IsClause ? model.ClauseId : null;
                if (contractFile.IsClause)
                {
                    var filePath = _clauseService.FindByIdAsync((int)model.ClauseId).Result.FilePath;
                    StringBuilder content = await GetDocxContent(filePath, formatKeys);
                    contractFile.FilePath = await AddContractFile(filePath, PdfFormatKeys(formatKeys, content));
                }
                else
                {
                    if (readyDoc != null && MimeTypeCheckExtension.İsDocument(readyDoc))
                    {
                        contractFile.ClauseId = _clauseService.GetAllIncCompAsync(x => x.Key == ContractFileReadyConst.recruitment_labor_contract && !x.IsDeleted).Result[0].Id;
                        contractFile.FilePath = await AddFile("wwwroot/contractDocs/", readyDoc);
                        contractFile.CreatedDate = DateTime.Now;
                    }
                }
                await _contractFileService.AddAsync(contractFile);

                // Emr senedi
                var commandFile = new ContractFile
                {
                    ContractId = result_model.Id,
                    IsDeleted = false,
                    IsClause = true
                };
                var command_clause = _clauseService.GetAllIncCompAsync(x => x.Key == ContractFileReadyConst.recruitment_command && !x.IsDeleted).Result[0];
                commandFile.ClauseId = command_clause.Id;

                StringBuilder content1 = await GetDocxContent(command_clause.FilePath, formatKeys);
                commandFile.FilePath = await AddContractFile(command_clause.FilePath, PdfFormatKeys(formatKeys, content1));
                contractFile.CreatedDate = DateTime.Now;
                await _contractFileService.AddAsync(commandFile);
                // Mexfilik senedi
                var privacyFile = new ContractFile
                {
                    ContractId = result_model.Id,
                    IsDeleted = false,
                    IsClause = true
                };
                var privacy_clause = _clauseService.GetAllIncCompAsync(x => x.Key == ContractFileReadyConst.recruitment_privacy && !x.IsDeleted).Result[0];
                privacyFile.ClauseId = privacy_clause.Id;

                StringBuilder content2 = await GetDocxContent(privacy_clause.FilePath, formatKeys);
                privacyFile.FilePath = await AddContractFile(privacy_clause.FilePath, PdfFormatKeys(formatKeys, content2));
                privacyFile.CreatedDate = DateTime.Now;
                await _contractFileService.AddAsync(privacyFile);
                // Maddi mesuliyyet senedi
                var financialResponsibilityFile = new ContractFile
                {
                    ContractId = result_model.Id,
                    IsDeleted = false,
                    IsClause = true
                };
                var financial_clause = _clauseService.GetAllIncCompAsync(x => x.Key == ContractFileReadyConst.recruitment_financial_responsibility && !x.IsDeleted).Result[0];
                financialResponsibilityFile.ClauseId = financial_clause.Id;

                StringBuilder content3 = await GetDocxContent(financial_clause.FilePath, formatKeys);
                financialResponsibilityFile.FilePath = await AddContractFile(financial_clause.FilePath, PdfFormatKeys(formatKeys, content3));
                financialResponsibilityFile.CreatedDate = DateTime.Now;
                await _contractFileService.AddAsync(financialResponsibilityFile);
                var category = await _categoryService
                    .AnyAsync(x => x.Name == "Məlumat"
                               || x.Name == "Melumat"
                               || x.Name == "Malumat");
                if (!category)
                {
                    var ctgr = new Category
                    {
                        Name = "Məlumat",
                        CreatedByUserId = GetSignInUserId(),
                        CreatedDate = DateTime.Now
                    };
                    await _categoryService.AddAsync(ctgr);
                }
                if (model.SendNews)
                {
                    var news = new News
                    {
                        Title = "Yeni Əməkdaş",
                        Description = "<p>Hörmətli əməkdaşlar,</p>\r\n\r\n" +
                                      "<p>SR komandasına yeni işçi qatılır!</p>" +
                                      $"\r\n\r\n<p><strong>{usr.Fullname}</strong></p>" +
                                      $"\r\n\r\n<p>{usr.Company.Name} ({usr.Position.Name})</p> <p>&nbsp;</p>\r\n\r\n" +
                                      "\r\n\r\n<p>İş yeri ilə tanış olmasına,</p> <p>&nbsp;</p>\r\n\r\n" +
                                      "ona şirkətimizin xoş atmosferinə mümkün qədər" +
                                      "\r\n\r\n tez uyğunlaşmasına  kömək edəcəyinizə inanırıq və </p> <p>&nbsp;</p>\r\n\r\n" +
                                      "əməkdaşımıza uğurlar arzu edirik!</p>\r\n\r\n",
                        AppUserId = null,
                        CreatedByUserId = current,
                        CreatedDate = DateTime.Now
                    };
                    var newsResult = await _newsService.AddReturnEntityAsync(news);
                    var newsCategoryId = await _categoryService
                        .GetAsync(x => x.Name == "Məlumat"
                                       || x.Name == "Melumat"
                                       || x.Name == "Malumat");
                    var newsFile = new NewsFile
                    {
                        Name = usr.Picture,
                        NewsId = newsResult.Id,
                        CreatedByUserId = current,
                        CreatedDate = DateTime.Now
                    };
                    var categoryNews = new CategoryNews
                    {
                        NewsId = newsResult.Id,
                        CategoryId = newsCategoryId.Id,
                        CreatedByUserId = current,
                        CreatedDate = DateTime.Now
                    };
                    await _newsFileService.AddAsync(newsFile);
                    await _categoryNewsService.AddAsync(categoryNews);
                };
                if (model.SendMail)
                {
                    _emailSender.ContractSendEmail(usr.Fullname, usr.Company.Name, usr.Department.Name, usr.Position.Name, usr.Picture);
                }
                return RedirectToAction("List", new
                {
                    success = Messages.Add.Added
                });
            }
        }



        [HttpGet]
        [Authorize(Policy = "contract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<ContractUpdateDto>(await _contractService.FindByIdAsync(id));

            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);


            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted == false));
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Id == usr.Id && x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.contractTypes = await _contractTypeService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.clauses = await _clauseService.GetAllAsync(x => !x.IsDeleted && !x.IsBackground);
            ViewBag.contractFiles = await _contractFileService.GetAllIncCompAsync(x => x.ContractId == id && !x.IsDeleted);
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "contract.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ContractUpdateDto model, IFormFile readyDoc)
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
                var data = await _contractService.FindByIdAsync(model.Id);
                var current = GetSignInUserId();
                var update = _map.Map<Contract>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                await _contractService.UpdateAsync(update);

                // Keys formats
                var usr = await _appUserService.FindByUserAllInc(update.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();
                formatKeys.Add("contractDate", model.ContractStart.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                formatKeys.Add("contractDatePlus", model.ContractStart.AddYears(1).ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                if (model.ContractEnd != null)
                    formatKeys.Add("contractDateEnd", model.ContractEnd?.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));

                if (model.HasTerm)
                {
                    var range = model.ContractStart.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")) + " tarixindən " + model.ContractEnd?.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")) + " tarixinədək ";
                    formatKeys.Add("contractDateRange", range);
                }
                else
                {
                    formatKeys.Add("contractDateRange", " müddətsiz ");
                }

                formatKeys.Add("contractNumber", model.ContractNumber);
                formatKeys.Add("commandNumber", model.CommandNumber);
                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                formatKeys.Add("isAlternate", model.IsAlternate ? "növbəli" : "növbəsiz");
                formatKeys.Add("byTransport", model.ByTransport ? "edilir" : "edilmir");
                formatKeys.Add("hasTerm", model.HasTerm ? "li" : "siz");

                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                //

                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.ContractId == model.Id && !x.IsDeleted);
                foreach (var el in contract_files)
                {
                    if (el.Clause.Key != ContractFileReadyConst.recruitment_command &&
                        el.Clause.Key != ContractFileReadyConst.recruitment_financial_responsibility &&
                        el.Clause.Key != ContractFileReadyConst.recruitment_privacy)
                    {
                        if (update.ContractFileType == ContractConst.UPLOAD_FILE)
                        {
                            if (readyDoc != null && MimeTypeCheckExtension.İsDocument(readyDoc))
                            {
                                DeleteFile("wwwroot/contractDocs/", el.FilePath);
                                el.IsClause = false;
                                el.FilePath = await AddFile("wwwroot/contractDocs/", readyDoc);
                                await _contractFileService.UpdateAsync(el);

                            }
                        }
                        else
                        {
                            var clause = _clauseService.GetAllIncCompAsync(x => x.Id == update.ClauseId && !x.IsDeleted).Result[0];
                            DeleteFile("wwwroot/contractDocs/", el.FilePath);

                            StringBuilder content = await GetDocxContent(clause.FilePath, formatKeys);
                            var new_el = _contractFileService.FindByIdAsync(el.Id).Result;
                            new_el.FilePath = await AddContractFile(clause.FilePath, PdfFormatKeys(formatKeys, content));
                            new_el.IsClause = true;
                            new_el.ClauseId = update.ClauseId;
                            await _contractFileService.UpdateAsync(new_el);
                        }
                    }
                    else
                    {
                        var clause = _clauseService.GetAllIncCompAsync(x => x.Id == el.ClauseId && !x.IsDeleted).Result[0];
                        DeleteFile("wwwroot/contractDocs/", el.FilePath);

                        StringBuilder content = await GetDocxContent(clause.FilePath, formatKeys);
                        el.FilePath = await AddContractFile(clause.FilePath, PdfFormatKeys(formatKeys, content));
                        el.IsClause = true;
                        await _contractFileService.UpdateAsync(el);
                    }


                }
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "contract.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = await _contractService.FindByIdAsync(id);
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _contractService.UpdateAsync(_map.Map<Contract>(transactionModel));
        }
    }
}
