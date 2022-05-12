using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.FileUploader;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class CompanyController : BaseIdentityController
    {
        private readonly ICompanyService _companyService;
        private readonly IFileManager _upload;
        public CompanyController
            (
            IMapper map,
            ICompanyService companyService,
            IFileManager upload,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _companyService = companyService;
            _upload = upload;
        }
        [HttpGet]
        [Authorize(Policy = "company.list")]
        public async Task<IActionResult> List()
        {
            var model = await _companyService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
                return View(_map.Map<List<CompanyListDto>>(model));
            }
            return View(new List<CompanyListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "company.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map
                .Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "company.add")]
        public async Task<IActionResult> Add(CompanyAddDto model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                if (!(logo is null) && logo.FileName != "logoDefault.png")
                {
                    if (!MimeTypeCheckExtension.İsImage(logo))
                    {
                        TempData["error"] = Messages.Error.wrongFormat;
                    }
                    else
                    {
                        model.LogoPath = _upload.UploadResizedImg(logo, "wwwroot/logo/");
                    }
                }
                var add = _map.Map<Company>(model);
                add.CreatedByUserId = GetSignInUserId();
                if (await _companyService.AddReturnEntityAsync(add) is null)
                {
                    TempData["error"] = Messages.Add.notAdded;
                    return RedirectToAction("List");
                }
                TempData["success"] = Messages.Add.Added;
                return RedirectToAction("List");
            }
            else
            {
                TempData["error"] = Messages.Error.notComplete;
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        [Authorize(Policy = "company.Update")]
        public async Task<IActionResult> Update(int Id)
        {
            var data = _map.Map<CompanyUpdateDto>(await _companyService.FindByIdAsync(Id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted == false));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "company.Update")]
        public async Task<IActionResult> Update(CompanyUpdateDto model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                var data = await _companyService.FindByIdAsync(model.Id);
                if (!(logo is null) && logo.FileName != "logoDefault.png")
                {
                    _upload.Delete(data.LogoPath, "wwwroot/logo/");
                    model.LogoPath = _upload.UploadResizedImg(logo, "wwwroot/logo/");
                }
                else if (!(logo is null))
                {
                    model.LogoPath = "logoDefault.png";
                }
                else
                {
                    model.LogoPath = data.LogoPath;
                }
                var update = _map.Map<Company>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _companyService.UpdateAsync(update);
                TempData["success"] = Messages.Update.Updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");

        }
        [Authorize(Policy = "company.delete")]
        public async Task Delete(int id)
        {
            var delete = await _companyService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _companyService.UpdateAsync(delete);
        }
    }
}
