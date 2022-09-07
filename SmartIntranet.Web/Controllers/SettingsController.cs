using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Core.Extensions;

namespace SmartIntranet.Web.Controllers
{
    public class SettingsController : BaseIdentityController
    {
        private readonly ISettingsService _settingsService;
        private readonly IFileService _upload;

        public SettingsController(
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            ISettingsService settingsService,
            IMapper map, IFileService upload)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _settingsService = settingsService;
            _upload = upload;
        }
        [Authorize(Policy = "settings.index")]
        public IActionResult Index()
        {
            var model = _settingsService.Get();
            return View(model != null ? _map.Map<SettingsDto>(model) : new SettingsDto());
        }
        [HttpPost]
        [Authorize(Policy = "settings.index")]
        public async Task<IActionResult> Index(SettingsDto model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    var data = await _settingsService.FindByIdAsync(model.Id);
                    if (!(logo is null) && logo.FileName != "logoDefault.png")
                    {
                        _upload.Delete(data.CompanyLogo, "wwwroot/logo/");
                        model.CompanyLogo = await _upload.UploadResizedImg(logo, "wwwroot/logo/");
                    }
                    else if (!(logo is null))
                    {
                        model.CompanyLogo = "logoDefault.png";
                    }
                    else
                    {
                        model.CompanyLogo = data.CompanyLogo;
                    }
                    var update = _map.Map<Settings>(model);
                    update.UpdateByUserId = GetSignInUserId();
                    update.CreatedByUserId = data.CreatedByUserId;
                    update.DeleteByUserId = data.DeleteByUserId;
                    update.CreatedDate = data.CreatedDate;
                    update.UpdateDate = DateTime.Now;
                    update.DeleteDate = data.DeleteDate;

                    await _settingsService.UpdateAsync(update);
                    TempData["success"] = Messages.Update.updated;
                    return View(_map.Map<SettingsDto>(await _settingsService.FindByIdAsync(model.Id)));
                }
                if (!(logo is null) && logo.FileName != "logoDefault.png")
                {
                    if (!MimeTypeCheckExtension.İsImage(logo))
                    {
                        TempData["error"] = Messages.Error.wrongFormat;
                    }
                    else
                    {
                        model.CompanyLogo = await _upload.UploadResizedImg(logo, "wwwroot/logo/");
                    }
                }
                var add = _map.Map<Settings>(model);
                add.CreatedDate = DateTime.Now;
                add.CreatedByUserId = GetSignInUserId();

                await _settingsService.UpdateAsync(add);
                TempData["success"] = Messages.Update.updated;
                return View();
            }
            TempData["error"] = Messages.Error.notComplete;
            return View(model);
        }
    }
}
