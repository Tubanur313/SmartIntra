﻿using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{
    [Authorize]
    public class CheckListController : BaseIdentityController
    {
        private readonly ICheckListService _checkListService;
        public CheckListController(
            IMapper map,
            ICheckListService checkListService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _checkListService = checkListService;
        }
        [HttpGet]
        [Authorize(Policy = "checkList.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _checkListService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<CheckListListDto>>(model));
            }
            return View(new List<CheckListListDto>());
        }
        [Authorize(Policy = "checkList.add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "checkList.add")]
        public async Task<IActionResult> Add(CheckListAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<CheckList>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.UtcNow;
                //if (await _checkListService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                if (await _checkListService.AddReturnEntityAsync(add) is null)
                {return RedirectToAction("List", new
                {
                    error = Messages.Add.notAdded
                });
                }
                TempData["success"] = Messages.Add.Added;
                return RedirectToAction("List");
            }
            else
            {return RedirectToAction("List", new
            {
                error = Messages.Error.notComplete
            });
            }
        }
        [HttpGet]
        [Authorize(Policy = "checkList.update")]
        public async Task<IActionResult> Update(int Id)
        {
            var data = _map.Map<CheckListUpdateDto>(await _checkListService.FindByIdAsync(Id));
            if (data is null)
            {return RedirectToAction("List", new
            {
                error = Messages.Error.notFound
            });
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "checkList.update")]
        public async Task<IActionResult> Update(CheckListUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _checkListService.FindByIdAsync(model.Id);
                var update = _map.Map<CheckList>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.UtcNow;
                update.DeleteDate = data.DeleteDate;
                //if (await _checkListService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                await _checkListService.UpdateAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            return RedirectToAction("List", new
            {
                error = Messages.Error.notComplete
            });

        }
        [Authorize(Policy = "checkList.delete")]
        public async Task Delete(int id)
        {
            var delete = await _checkListService.GetAsync(x=>x.Id==id && x.IsDeleted==false);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.UtcNow;
            delete.IsDeleted = true;
            await _checkListService.UpdateAsync(delete);
        }
    }
}
