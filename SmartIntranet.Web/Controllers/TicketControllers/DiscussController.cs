using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DTO.DTOs.DiscussionDto;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Web.Controllers.TicketControllers
{
    public class DiscussController : BaseIdentityController
    {
        private readonly IDiscussionService _discussionService;
        public DiscussController
            (
            IMapper map,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IDiscussionService discussionService
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _discussionService = discussionService;
        }

        [HttpGet]   
        public async Task<IActionResult> GetDiscuss(int ticketId)
        {
            var discuss = _map
                .Map<List<DiscussionListSecondDto>>(await _discussionService.GetAllByTicketAsync(ticketId));
            return PartialView("_discuss", discuss);
        }
    }
}
