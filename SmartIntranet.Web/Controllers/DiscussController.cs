using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.DiscussionDto;
using SmartIntranet.DTO.DTOs.OrderDto;
using SmartIntranet.DTO.DTOs.TicketDto;
using SmartIntranet.DTO.DTOs.TicketOrderDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
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
