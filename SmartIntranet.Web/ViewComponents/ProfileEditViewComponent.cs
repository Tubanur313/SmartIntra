using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Membership;

namespace SmartIntranet.Web.ViewComponents
{
    public class ProfileEditViewComponent : ViewComponent
    {
        private readonly UserManager<IntranetUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _map;
        public ProfileEditViewComponent(UserManager<IntranetUser> userManager,IAppUserService appUserService, IMapper map)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _map = map;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var identityUserName = _userManager.FindByNameAsync(User.Identity.Name).Result;
           var models=  _map.Map<AppUserProfileDto>(await _appUserService.FindByUserAllInc(identityUserName.Id));
            return View(models);
        }
    }
}
