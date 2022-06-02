using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Web.Controllers
{
    public class CompanyController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly IAppUserService _appUserService;
        public CompanyController(UserManager<IntranetUser> userManager, IAppUserService appUserService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, ICompanyService companyService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {

            _mapper = mapper;
            _companyService = companyService;
            _appUserService = appUserService;
        }

        [Authorize(Policy = "company.list")]
        public async Task<IActionResult> List()
        {
            return View(_mapper.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
        }

        [HttpGet]
        [Authorize(Policy = "company.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _mapper.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "company.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CompanyAddDto model, IFormFile logo)
        {

            if (ModelState.IsValid)
            {
                if (logo != null && logo.FileName != "logoDefault.png")
                {
                  //  model.LogoPath = AddResizedImage("wwwroot/logo/", logo);
                }
                model.CreatedByUserId = GetSignInUserId();
                await _companyService.AddAsync(_mapper.Map<Company>(model));

                return RedirectToAction("List");

            }
            else
            {

                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        [Authorize(Policy = "company.update")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.companies = _mapper.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.Leader = _mapper.Map<ICollection<AppUserListDto>>(await _appUserService.GetAllIncludeAsync(x => x.IsDeleted  == false && x.CompanyId == id));
            var listModel = _mapper.Map<CompanyUpdateDto>(await _companyService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "company.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CompanyUpdateDto model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {

                if (logo != null && logo.FileName != "logoDefault.png")
                {
                   // model.LogoPath = AddResizedImage("wwwroot/logo/", logo);
                }
                else if (logo != null)
                {
                    model.LogoPath = "logoDefault.png";
                }
                else
                {
                    var company = await _companyService.FindByIdAsync(model.Id);
                    model.LogoPath = company.LogoPath;

                }
                var current = GetSignInUserId();
                model.UpdateDate = DateTime.UtcNow.AddHours(4);
                model.UpdateByUserId = current;
                var oldFileImg = await _companyService.FindByIdAsync(model.Id);
                var result = await _companyService.UpdateReturnEntityAsync(_mapper.Map<Company>(model));
                if (result!=null && oldFileImg.LogoPath != "logoDefault.png")
                {
                    TempData["msg"] = DeleteFile("wwwroot/logo/", oldFileImg.LogoPath);
                }

                //return Json(new { isValid = true, html = RazorHelper.RenderRazorViewToString(this, "_ViewAll", _mapper.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync())) });
                return RedirectToAction("List");

            }
            TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
            return RedirectToAction("List");


        }
        [Authorize(Policy = "company.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            //var currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var current = GetSignInUserId();

            var transactionModel = _mapper.Map<CompanyListDto>(await _companyService.FindByIdAsync(id));
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _companyService.UpdateAsync(_mapper.Map<Company>(transactionModel));
            return Ok();
        }

    }
}
