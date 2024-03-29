﻿using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlConverter = iText.Html2pdf.HtmlConverter;
using SmartIntranet.Core.Extensions;

namespace SmartIntranet.Web.Controllers
{
    public class ContractController : BaseIdentityController
    {
        private readonly IMapper _mapper;
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

        public ContractController(UserManager<IntranetUser> userManager, IAppUserService appUserService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, ITerminationContractService terminationContractService, IMapper mapper, IContractService contractService, IPersonalContractService personalContractService, IContractFileService contractFileService, IClauseService clauseService,  IContractTypeService contractTypeService, IVacationContractService vacationContractService, IAppUserService userService, IWorkGraphicService workGraphicService, ICompanyService companyService,  IBusinessTripService businessTripService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _mapper = mapper;
            _contractService = contractService;
            _personalContractService = personalContractService;
            _terminationContractService = terminationContractService;
            _vacationContractService = vacationContractService;
            _contractTypeService = contractTypeService;
            _contractFileService = contractFileService;
            _userService = userService;
            _clauseService = clauseService;
            _workGraphicService = workGraphicService;
            _companyService = companyService;
            _appUserService = appUserService;
            _businessTripService = businessTripService;
        }

        [Authorize(Policy = "contract.list")]
        public async Task<IActionResult> List()
        {
            ViewBag.contractTypes = await _contractTypeService.GetAllAsync(x => !x.IsDeleted);
            List<ContractListDto> result_list = new List<ContractListDto>();
            var contracts = _mapper.Map<List<ContractListDto>>(await _contractService.GetAllIncCompAsync(x => !x.IsDeleted));

            var work_accept = "WORK_ACCEPT";
            var el_work_accept = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == work_accept).Result[0].Name;
            foreach (var el in contracts)
            {
                el.ContractKey = work_accept;
                el.ContractName = el_work_accept;
                result_list.Add(el);
            }

            var personal_contracts = _mapper.Map<List<ContractListDto>>(await _personalContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var personal_chg = "PERSONAL_CHG";
            var el_personal_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == personal_chg).Result[0].Name;
                foreach (var el in personal_contracts)
            {
                el.ContractKey = personal_chg;
                el.ContractName = el_personal_chg;
                result_list.Add(el);
            }


            var vacation_contracts = _mapper.Map<List<ContractListDto>>(await _vacationContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var vacation_chg = "VACATION";
            var el_vacation_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == vacation_chg).Result[0].Name;
            foreach (var el in vacation_contracts)
            {
                el.ContractKey = vacation_chg;
                el.ContractName = el_vacation_chg;
                result_list.Add(el);
            }

            var business_trips_org = await _businessTripService.GetAllIncAsync(x => !x.IsDeleted);
            var business_trips = _mapper.Map<List<ContractListDto>>(business_trips_org);
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

            var termination_contracts = _mapper.Map<List<ContractListDto>>(await _terminationContractService.GetAllIncCompAsync(x => !x.IsDeleted));
            var termination_chg = "TERMINATION";
            var el_termination_chg = _contractTypeService.GetAllIncCompAsync(x => !x.IsDeleted && x.Key == termination_chg).Result[0].Name;
            foreach (var el in termination_contracts)
            {
                el.ContractKey = termination_chg;
                el.ContractName = el_termination_chg;
                result_list.Add(el);
            }

             result_list = result_list.OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList();
            return View(result_list);
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
            ViewBag.companies = _mapper.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.users = _mapper.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.clauses = await _clauseService.GetAllAsync(x=> !x.IsDeleted && !x.IsBackground);
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "contract.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ContractAddDto model, IFormFile readyDoc)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {

             
                var current = GetSignInUserId();
                var result_model =  _contractService.AddReturnEntityAsync(_mapper.Map<Contract>(model)).Result;

                // Keys formats
                var usr = await _appUserService.FindByUserAllInc(result_model.UserId);
                var usr2 = await _userManager.FindByIdAsync(model.UserId.ToString());
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();
                formatKeys.Add("contractDate", result_model.ContractStart.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                if (result_model.ContractEnd != null)
                    formatKeys.Add("contractDateEnd", result_model.ContractEnd.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
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
                var contractFile = new ContractFile();
                contractFile.ContractId = result_model.Id;
                contractFile.IsDeleted = false;
                contractFile.IsClause = model.ContractFileType == ContractConst.TEMPLATE ? true : false;
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
                    }
                }
                await _contractFileService.AddAsync(contractFile);

                // Emr senedi
                var commandFile = new ContractFile();
                commandFile.ContractId = result_model.Id;
                commandFile.IsDeleted = false;
                commandFile.IsClause = true;
                var command_clause = _clauseService.GetAllIncCompAsync(x=>x.Key == ContractFileReadyConst.recruitment_command && !x.IsDeleted).Result[0];
                commandFile.ClauseId = command_clause.Id;

                StringBuilder content1 = await GetDocxContent(command_clause.FilePath, formatKeys);
                commandFile.FilePath = await AddContractFile(command_clause.FilePath, PdfFormatKeys(formatKeys, content1));

                await _contractFileService.AddAsync(commandFile);
                // Mexfilik senedi
                var privacyFile = new ContractFile();
                privacyFile.ContractId = result_model.Id;
                privacyFile.IsDeleted = false;
                privacyFile.IsClause = true;
                var privacy_clause = _clauseService.GetAllIncCompAsync(x => x.Key == ContractFileReadyConst.recruitment_privacy && !x.IsDeleted).Result[0];
                privacyFile.ClauseId = privacy_clause.Id;

                StringBuilder content2 = await GetDocxContent(privacy_clause.FilePath, formatKeys);
                privacyFile.FilePath = await AddContractFile(privacy_clause.FilePath, PdfFormatKeys(formatKeys, content2));

                await _contractFileService.AddAsync(privacyFile);
                // Maddi mesuliyyet senedi
                var financialResponsibilityFile = new ContractFile();
                financialResponsibilityFile.ContractId = result_model.Id;
                financialResponsibilityFile.IsDeleted = false;
                financialResponsibilityFile.IsClause = true;
                var financial_clause = _clauseService.GetAllIncCompAsync(x => x.Key == ContractFileReadyConst.recruitment_financial_responsibility && !x.IsDeleted).Result[0];
                financialResponsibilityFile.ClauseId = financial_clause.Id;

                StringBuilder content3 = await GetDocxContent(financial_clause.FilePath, formatKeys);
                financialResponsibilityFile.FilePath = await AddContractFile(financial_clause.FilePath, PdfFormatKeys(formatKeys, content3));

                await _contractFileService.AddAsync(financialResponsibilityFile);
                return RedirectToAction("List");

            }
        }



        [HttpGet]
        [Authorize(Policy = "contract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _mapper.Map<ContractUpdateDto>(await _contractService.FindByIdAsync(id));
            
            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);


            ViewBag.companies = _mapper.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            ViewBag.users = _mapper.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
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
                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
            else
            {
                var current = GetSignInUserId();
                model.UpdateDate = DateTime.UtcNow.AddHours(4);
                model.UpdateByUserId = current;
                await _contractService.UpdateAsync(_mapper.Map<Contract>(model));

                // Keys formats
                var usr = await _appUserService.FindByUserAllInc(model.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                Dictionary<string, string> formatKeys = new Dictionary<string, string>();
                formatKeys.Add("contractDate", model.ContractStart.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                if (model.ContractEnd != null)
                    formatKeys.Add("contractDateEnd", model.ContractEnd.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                formatKeys.Add("contractNumber", model.ContractNumber);
                formatKeys.Add("commandNumber", model.CommandNumber);
                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy", new CultureInfo("az-Latn-AZ")));
                formatKeys.Add("isAlternate", model.IsAlternate ? "növbəli" : "növbəsiz");
                formatKeys.Add("byTransport", model.ByTransport ? "edilir" : "edilmir");
                formatKeys.Add("hasTerm", model.HasTerm ? "li" : "siz");

                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
                //

                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.ContractId == model.Id && !x.IsDeleted);
                foreach(var el in contract_files)
                {
                    if (el.Clause.Key == ContractFileReadyConst.recruitment_labor_contract && model.ContractFileType == ContractConst.UPLOAD_FILE)
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
                        var clause = _clauseService.GetAllIncCompAsync(x => x.Id == el.ClauseId && !x.IsDeleted).Result[0];
                        DeleteFile("wwwroot/contractDocs/", el.FilePath);

                        StringBuilder content = await GetDocxContent(clause.FilePath, formatKeys);
                        el.FilePath = await AddContractFile(clause.FilePath, PdfFormatKeys(formatKeys, content));
                        el.IsClause = true;
                        await _contractFileService.UpdateAsync(el);
                    }

                }
                return RedirectToAction("List");
            }
        }

        [Authorize(Policy = "contract.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = await _contractService.FindByIdAsync(id);
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _contractService.UpdateAsync(_mapper.Map<Contract>(transactionModel));
            return Ok();

        }


    }
}
