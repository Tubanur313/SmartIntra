using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{
    public class TicketCheckListController : BaseIdentityController
    {
        private readonly ITicketCheckListService _ticketCheckListService;
        public TicketCheckListController(
            IMapper map,
            ITicketCheckListService ticketCheckListService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _ticketCheckListService = ticketCheckListService;
        }

        [Authorize(Policy = "ticketchecklist.confirmed")]
        public async Task<IActionResult> Confirmed(int id, bool active)
        {
            var conf = await _ticketCheckListService.FindByIdAsync(id);
            if (conf != null)
            {
                conf.UpdateByUserId = GetSignInUserId();
                conf.UpdateDate = DateTime.Now;
                conf.Confirm = active;
                await _ticketCheckListService.UpdateModifiedAsync(conf);
                return Ok(new
                {
                    active = active,
                    message = active ? "təsdiqləndi" : "təsdiq ləğv edildi"
                });
            }
            return NotFound(new
            {
                active = active,
                message = "təsdiqlənmədi"
            });
        }
        [Authorize(Policy = "ticketchecklist.delete")]
        public async Task Delete(int id)
        {
           await _ticketCheckListService.DeleteByIdAsync(id);
        }
    }
}
