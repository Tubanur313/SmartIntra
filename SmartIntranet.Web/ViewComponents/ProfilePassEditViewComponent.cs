using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SmartIntranet.Web.ViewComponents
{
    public class ProfilePassEditViewComponent : ViewComponent
    {

        private readonly UserManager<IntranetUser> _userManager;
        private readonly IMapper _map;
        public ProfilePassEditViewComponent(UserManager<IntranetUser> userManager,IAppUserService appUserService, IMapper map)
        {
            _userManager = userManager;
            _map = map;
        }

        public IViewComponentResult Invoke()
        {
            var identityUserName = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _map.Map<AppUserPassDto>(identityUserName);
            return View(model);
        }
    }
}
