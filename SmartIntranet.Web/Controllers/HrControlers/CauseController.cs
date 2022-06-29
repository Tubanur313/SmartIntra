﻿using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CauseDto;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.NonWorkingDayDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Core.Utilities.Messages;

namespace SmartIntranet.Web.Controllers
{
    public class CauseController : BaseIdentityController
    {
        private readonly ICauseService _causeService;
        public CauseController(UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper mapper, ICauseService causeService)
            : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _causeService = causeService;
        }
        [Authorize(Policy = "cause.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            TempData["success"] = success;
            TempData["error"] = error;
            IEnumerable<CauseListDto> data = _map.
                Map<ICollection<CauseListDto>>(await _causeService
                .GetAllIncAsync(x => !x.IsDeleted))
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToList();
            return View(data);
        }

        [HttpGet]
        [Authorize(Policy = "cause.add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "cause.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CauseAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Cause>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.Now;
                if (await _causeService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "cause.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<CauseUpdateDto>(await _causeService.FindByIdAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }

            return View(data);
        }

        [HttpPost]
        [Authorize(Policy = "cause.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CauseUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _causeService.FindByIdAsync(model.Id);
                var update = _map.Map<Cause>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _causeService.UpdateAsync(update);
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

        [Authorize(Policy = "cause.delete")]
        public async Task Delete(int id)
        {
            var delete = await _causeService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _causeService.UpdateAsync(delete);
        }
    }
}
