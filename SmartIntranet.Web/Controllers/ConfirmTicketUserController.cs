using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{
    public class ConfirmTicketUserController : BaseIdentityController
    {
        private readonly IConfirmTicketUserService _confirmTicketUserService;
        public ConfirmTicketUserController(
            IMapper map,
            IConfirmTicketUserService confirmTicketUserService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _confirmTicketUserService = confirmTicketUserService;
        }
        [Authorize(Policy = "confirmTicketUser.confirmed")]
        public async Task<IActionResult> Confirmed(int id, bool active)
        {
            var conf = await _confirmTicketUserService.FindByIdAsync(id);
            if (conf != null)
            {
                conf.UpdateByUserId = GetSignInUserId();
                conf.UpdateDate = DateTime.Now;
                conf.ConfirmTicket = active;
                await _confirmTicketUserService.UpdateModifiedAsync(conf);
                return Ok(new
                {
                    active = active,
                    message = active? "təsdiqləndi": "təsdiq ləğv edildi"
                });
            }
            return NotFound(new
            {
                active = active,
                message = "təsdiqlənmədi"
            });
        }
        [Authorize(Policy = "confirmTicketUser.delete")]
        public async Task Delete(int id)
        {
            await _confirmTicketUserService.DeleteByIdAsync(id);
        }

    }
}
