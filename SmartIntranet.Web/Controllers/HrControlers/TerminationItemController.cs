using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.TerminationItemDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Core.Utilities.Messages;
using System.Linq;

namespace SmartIntranet.Web.Controllers
{
    public class TerminationItemController : BaseIdentityController
    {
        private readonly ITerminationItemService _terminationService;
        public TerminationItemController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, ITerminationItemService terminationService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _terminationService = terminationService;
        }
        [Authorize(Policy = "terminationItem.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = _map.Map<ICollection<TerminationItemListDto>>(await _terminationService.GetAllIncCompAsync(x => !x.IsDeleted));
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<ICollection<TerminationItemListDto>>(model).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
            }
            return View(new List<TerminationItemListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "terminationItem.add")]
        public IActionResult Add()
        {
            return View();
        }

      

        [HttpPost]
        [Authorize(Policy = "terminationItem.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TerminationItemAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var current = GetSignInUserId();
                var add = _map.Map<TerminationItem>(model);
                add.CreatedByUserId = current;
                add.CreatedDate = DateTime.Now;
                add.IsDeleted = false;
                if (await _terminationService.AddReturnEntityAsync(add) is null)
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
        }

        [HttpGet]
        [Authorize(Policy = "terminationItem.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<TerminationItemUpdateDto>(await _terminationService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "terminationItem.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TerminationItemUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var data = await _terminationService.FindByIdAsync(model.Id);
                var current = GetSignInUserId();
                var update = _map.Map<TerminationItem>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                await _terminationService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "terminationItem.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<TerminationItemListDto>(await _terminationService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _terminationService.UpdateAsync(_map.Map<TerminationItem>(transactionModel));
        }
    }
}
