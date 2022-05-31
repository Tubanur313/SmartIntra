using AutoMapper;
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
        public async Task<IActionResult> List()
        {
            var model = await _stockCategoryService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
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
                if (await _stockCategoryService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                if (await _stockCategoryService.AddReturnEntityAsync(add) is null)
                {
                    TempData["error"] = Messages.Add.notAdded;
                    return RedirectToAction("List");
                }
                TempData["success"] = Messages.Add.Added;
                return RedirectToAction("List");
            }
            else
            {
                TempData["error"] = Messages.Error.notComplete;
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        [Authorize(Policy = "stockcategory.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<StockCategoryUpdateDto>(await _stockCategoryService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
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
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                if (await _stockCategoryService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                await _stockCategoryService.UpdateAsync(update);
                TempData["success"] = Messages.Update.updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }

        [Authorize(Policy = "stockcategory.delete")]
        public async Task Delete(int id)
        {
            var delete = await _stockCategoryService.FindByIdAsync(id);
            delete.IsDeleted = true;
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            await _stockCategoryService.UpdateAsync(delete);
        }
    }
}
