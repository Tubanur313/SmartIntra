using AutoMapper;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SmartIntranet.Web.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly UserManager<IntranetUser> _userManager;
        private readonly IMapper _mapper;
        public ProfileViewComponent(UserManager<IntranetUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var identityUserName = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserInfoDto>(identityUserName);
            return View(model);
        }
    }
}
