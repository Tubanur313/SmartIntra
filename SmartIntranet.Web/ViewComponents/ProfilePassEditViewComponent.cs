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

namespace SmartIntranet.Web.ViewComponents
{
    public class ProfilePassEditViewComponent : ViewComponent
    {

        private readonly UserManager<IntranetUser> _userManager;
        private readonly IMapper _mapper;
        public ProfilePassEditViewComponent(UserManager<IntranetUser> userManager,IAppUserService appUserService, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var identityUserName = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserPassDto>(identityUserName);
            return View(model);
        }
    }
}
