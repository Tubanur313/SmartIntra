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

namespace SmartIntranet.Web.Controllers
{
    public class SettingsController : BaseIdentityController
    {
        private readonly ISettingsService _settingsService;
        public SettingsController(
            UserManager<IntranetUser> userManager, 
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            ISettingsService settingsService,
            IMapper map)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _settingsService = settingsService;
        }
        [Authorize(Policy = "settings.index")]
        public async Task<IActionResult> Index()
        {
            var model = _settingsService.Get();
            return View(model != null ? _map.Map<SettingsDto>(model) : new SettingsDto());
        }
        [HttpPost]
        [Authorize(Policy = "settings.index")]
        public async Task<IActionResult> Index(SettingsDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _settingsService.FindByIdAsync(model.Id);
                var update = _map.Map<Settings>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _settingsService.UpdateAsync(update);
                TempData["success"] = Messages.Update.updated;
                return View();
            }
            TempData["error"] = Messages.Error.notComplete;
            return View(model);
        }
    }
}
