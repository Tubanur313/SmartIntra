using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.EmailDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class SmtpEmailController : BaseIdentityController
    {
        private readonly ISmtpEmailService _emailService;
        public SmtpEmailController(
            UserManager<IntranetUser> userManager, 
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            ISmtpEmailService emailService,
            IMapper map)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _emailService.GetAsync();
            if (model != null )
            {
                return View(_map.Map<EmailListDto>(model));
            }
            return View(new EmailListDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(EmailListDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _emailService.FindByIdAsync(model.Id);
                var update = _map.Map<SMTPEmailSetting>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _emailService.UpdateAsync(update);
                TempData["success"] = Messages.Update.Updated;
                return View();
            }
            TempData["error"] = Messages.Error.notComplete;
            return View(model);
        }
    }
}
