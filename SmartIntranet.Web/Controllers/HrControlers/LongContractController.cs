using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.PersonalContractDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.Entities.Concrete;
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

namespace SmartIntranet.Web.Controllers
{
    public class LongContractController : BaseIdentityController
    {
        private readonly ILongContractService _contractService;
        private readonly ILongContractFileService _contractFileService;
        private readonly IAppUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IClauseService _clauseService;

        public LongContractController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, ILongContractService contractService, ILongContractFileService contractFileService, IClauseService clauseService,IAppUserService userService, ICompanyService companyService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _contractService = contractService;
            _contractFileService = contractFileService;
            _userService = userService;
            _clauseService = clauseService;
            _companyService = companyService;
        }


        [HttpGet]
        [Authorize(Policy = "longContract.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "longContract.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(LongContractAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.IsDeleted = false;
                model.CreatedDate = DateTime.UtcNow;
                var current = GetSignInUserId();
                var result_model = _contractService.AddReturnEntityAsync(_map.Map<LongContract>(model)).Result;
                var usr = await _userService.FindByUserAllInc(result_model.UserId);
                var usr2 = await _userManager.FindByIdAsync(result_model.UserId.ToString());
                var company = await _companyService.FindByIdAsync((int)usr2.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

               
                formatKeys.Add("fromDate", model.FromDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("toDate", model.ToDate.ToString("dd.MM.yyyy"));
                var doc_key = "long_contract";
                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
              

                var file_extra = new LongContractFile();
                file_extra.LongContractId = result_model.Id;
                file_extra.IsDeleted = false;

                var clause_result_extra = (await _clauseService.GetAllIncCompAsync(x => x.Key == doc_key && !x.IsDeleted))[0];
                file_extra.ClauseId = clause_result_extra.Id;
                StringBuilder content_extra = await GetDocxContent(clause_result_extra.FilePath, formatKeys);
                file_extra.FilePath = await AddContractFile(clause_result_extra.FilePath, PdfFormatKeys(formatKeys, content_extra));
                file_extra.CreatedDate = DateTime.UtcNow;
                await _contractFileService.AddAsync(file_extra);

                return RedirectToAction("List", "Contract");
            }
        }

        [HttpGet]
        [Authorize(Policy = "longContract.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<LongContractUpdateDto>(await _contractService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByIdAsync(listModel.UserId.ToString());
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);
          
            ViewBag.users = _map.Map<ICollection<IntranetUser>>(await _userService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted));
            ViewBag.contractFiles = await _contractFileService.GetAllIncCompAsync(x => x.LongContractId == id && !x.IsDeleted);

            return View(listModel);
        }

      

        [HttpPost]
        [Authorize(Policy = "longContract.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LongContractUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List", "Contract");
            }
            else
            {
                var current = GetSignInUserId();
                model.UpdateDate = DateTime.UtcNow;
                model.UpdateByUserId = current;
                await _contractService.UpdateAsync(_map.Map<LongContract>(model));

                var usr = await _userService.FindByUserAllInc(model.UserId);
                var company = await _companyService.FindByIdAsync((int)usr.CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

               
               
                formatKeys.Add("fromDate", model.FromDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("toDate", model.ToDate.ToString("dd.MM.yyyy"));
                var doc_key = "long_contract";
                usr = await _userService.FindByUserAllInc(model.UserId);
                formatKeys = PdfStaticKeys(formatKeys, usr, company, company_director);
               
                var contract_files = await _contractFileService.GetAllIncCompAsync(x => x.LongContractId == model.Id && !x.IsDeleted);
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

        [Authorize(Policy = "longContract.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var current = GetSignInUserId();
            var transactionModel = _map.Map<LongContractListDto>(await _contractService.FindByIdAsync(id));
            transactionModel.DeleteDate = DateTime.UtcNow;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _contractService.UpdateAsync(_map.Map<LongContract>(transactionModel));
            return Ok();

        }


    }
}
