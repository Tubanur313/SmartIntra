using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet.FAQ;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.FaqDto;
using SmartIntranet.Entities.Concrete.Intranet.FAQ;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InfoControllers
{
    public class FaqController : BaseIdentityController
    {
        private readonly IFaqService _faqService;
        private readonly IFileService _upload;
        public FaqController(UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper map,
            IFileService upload,
            IFaqService faqService)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _upload = upload;
            _faqService = faqService;
        }
        [HttpGet]
        [Authorize(Policy = "faq.info")]
        public async Task<IActionResult> Info()
        {
            var model = await _faqService.GetAllAsync(x=>!x.IsDeleted);
            if (model.Count > 0)
            {
                return View(_map.Map<List<FaqListDto>>(model));
            }
            return View(new List<FaqListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "faq.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _faqService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<FaqListDto>>(model));
            }
            return View(new List<FaqListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "faq.add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "faq.add")]
        public async Task<IActionResult> Add(FaqAddDto model, IFormFile faqFile)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Faq>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.Now;
                if (faqFile != null)
                {
                    add.File = await _upload.Upload(faqFile, "wwwroot/FAQs");
                }
                if (await _faqService.AddReturnEntityAsync(add) is null)
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Add.notAdded
                    });
                }
                return RedirectToAction("List", new
                {
                    success = Messages.Add.Added
                });
            }
            else
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
        }
        [HttpGet]
        [Authorize(Policy = "faq.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<FaqUpdateDto>(await _faqService.FindByIdAsync(id));
            if (data is null)
                return RedirectToAction("List", new { error = Messages.Error.notFound });
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "faq.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FaqUpdateDto model, IFormFile faqFile)
        {
            if (ModelState.IsValid)
            {
                var data = await _faqService.FindByIdAsync(model.Id);
                var update = _map.Map<Faq>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                if (faqFile != null)
                {
                    _upload.Delete(data.File, "wwwroot/FAQs");
                    update.File = await _upload.Upload(faqFile, "wwwroot/FAQs");
                }

                await _faqService.UpdateAsync(update);
                if (await _faqService.UpdateReturnEntityAsync(update) is null)
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Update.notUpdated
                    });
                }
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            else
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
        }

        [Authorize(Policy = "faq.delete")]
        public async Task Delete(int id)
        {
            var delete = await _faqService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _faqService.UpdateAsync(delete);
        }
    }
}