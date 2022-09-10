using AutoMapper;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs;

namespace SmartIntranet.Web.ViewComponents
{
    public class SettingViewComponent : ViewComponent
    {
        private readonly IMapper _map;
        private readonly ISettingsService _settingsService;
        public SettingViewComponent(UserManager<IntranetUser> userManager, IMapper map, 
            ISettingsService settingsService)
        {
            _map = map;
            _settingsService = settingsService;
        }

        public IViewComponentResult Invoke()
        {
            var settings = _settingsService.Get();
            var model = _map.Map<SettingsDto>(settings);
            return View(model);
        }
    }
}
