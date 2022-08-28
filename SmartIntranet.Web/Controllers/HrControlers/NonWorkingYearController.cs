using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Core.Utilities.Messages;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class NonWorkingYearController : BaseIdentityController
    {
        private readonly INonWOrkingYearService _nonWorkingYearService;
        public NonWorkingYearController(UserManager<IntranetUser> userManager, INonWOrkingYearService nonWorkingYearService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, INonWorkingDayService nonWorkingDayService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _nonWorkingYearService = nonWorkingYearService;
        }

        [Authorize(Policy = "nonworkingyear.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = _map.Map<ICollection<NonWorkingYearListDto>>(await _nonWorkingYearService.GetAllIncCompAsync(x => !x.IsDeleted));
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<ICollection<NonWorkingYearListDto>>(model).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
            }
            return View(new List<NonWorkingYearListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "nonworkingyear.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.Years = JsonConvert.SerializeObject((await _nonWorkingYearService.GetAllIncCompAsync(x => !x.IsDeleted)).Select(x => x.Year));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "nonworkingyear.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(NonWorkingYearAddDto model)
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
                var add = _map.Map<NonWorkingYear>(model);
                add.CreatedByUserId = current;
                add.CreatedDate = DateTime.Now;
                add.IsDeleted = false;
                if (await _nonWorkingYearService.AddReturnEntityAsync(add) is null)
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
        [Authorize]
        public async Task<IActionResult> GetNonWorkingYear(int nonWorkingYearId)
        {
            var nonWorkingYear = _map.Map<ICollection<NonWorkingYearListDto>>(
                await _nonWorkingYearService.GetAllAsync(x => x.IsDeleted  == false && x.Id == nonWorkingYearId))
                 .Select(x => new { x.Id, x.Year });

            return Ok(nonWorkingYear);
        }


        [HttpGet]
        [Authorize(Policy = "nonworkingyear.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<NonWorkingYearUpdateDto>(await _nonWorkingYearService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            ViewBag.Years = JsonConvert.SerializeObject((await _nonWorkingYearService.GetAllIncCompAsync(x => x.Id != id && !x.IsDeleted)).Select(x => x.Year));
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "nonworkingyear.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(NonWorkingYearUpdateDto model)
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
                var data = await _nonWorkingYearService.FindByIdAsync(model.Id);
                var update = _map.Map<NonWorkingYear>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                await _nonWorkingYearService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "nonworkingyear.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<NonWorkingYearListDto>(await _nonWorkingYearService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _nonWorkingYearService.UpdateAsync(_map.Map<NonWorkingYear>(transactionModel));
        }
    }
}
