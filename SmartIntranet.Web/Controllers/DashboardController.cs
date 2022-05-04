using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Entities.Concrete.Membership;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class DashboardController : BaseIdentityController
    {
        public DashboardController
       (
       IMapper map,
       UserManager<IntranetUser> userManager,
       IHttpContextAccessor httpContextAccessor,
       SignInManager<IntranetUser> signInManager
       ) : base(userManager, httpContextAccessor, signInManager, map)
        {
        }

        public async Task<IActionResult> Menu()
        {
            return View();
        }
    }
}
