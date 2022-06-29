﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InventaryControllers
{
    public class StockCategoryController : BaseIdentityController
    {

        private readonly IStockCategoryService _stockCategoryService;
        public StockCategoryController(IMapper map,
            IStockCategoryService stockCategoryService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _stockCategoryService = stockCategoryService;
        }
        [Authorize(Policy = "stockcategory.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _stockCategoryService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<StockCategoryListDto>>(model));
            }
            return View(new List<StockCategoryListDto>());

        }
        [HttpGet]
        [Authorize(Policy = "stockcategory.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.StockCategory = _map
                .Map<ICollection<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "stockcategory.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StockCategoryAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<StockCategory>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.UtcNow;
                //if (await _stockCategoryService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                if (await _stockCategoryService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "stockcategory.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<StockCategoryUpdateDto>(await _stockCategoryService.FindByIdAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            ViewBag.StockCategory = _map
                    .Map<ICollection<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "stockcategory.update")]
        public async Task<IActionResult> Update(StockCategoryUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _stockCategoryService.FindByIdAsync(model.Id);
                var update = _map.Map<StockCategory>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.UtcNow;
                update.DeleteDate = data.DeleteDate;
                //if (await _stockCategoryService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                if (await _stockCategoryService.UpdateReturnEntityAsync(update) is null)
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

        [Authorize(Policy = "stockcategory.delete")]
        public async Task Delete(int id)
        {
            var delete = await _stockCategoryService.FindByIdAsync(id);
            delete.IsDeleted = true;
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.UtcNow;
            await _stockCategoryService.UpdateAsync(delete);
        }
    }
}