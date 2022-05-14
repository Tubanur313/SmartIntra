using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    [Authorize]
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<IntranetUser> _userManager;
        //protected readonly RoleManager<IntranetUser> _roleManager;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly SignInManager<IntranetUser> _signInManager;
        protected readonly IMapper _map;
        public BaseIdentityController
            (
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper map
            )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _map = map;
        }

        protected int GetSignInUserId()
        {
            return _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
        }
        //protected string GetSignInUserRole()
        //{
        //    return _userManager.GetRolesAsync()
        //}


        protected void AddError(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
