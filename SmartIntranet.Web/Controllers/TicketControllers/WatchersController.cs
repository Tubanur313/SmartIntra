using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Web.Controllers.TicketControllers
{
    public class WatchersController : BaseIdentityController
    {
        private readonly IWatcherService _watcherService;
        public WatchersController(
            IMapper map,
            IWatcherService watcherService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _watcherService = watcherService;
        }
        [Authorize(Policy = "watchers.delete")]
        public async Task Delete(int id)
        {
            await _watcherService.DeleteByIdAsync(id);
        }

    }
}
