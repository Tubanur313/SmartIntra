using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InventaryControllers
{
    public class StockController : BaseIdentityController
    {

        private readonly IStockService _StockService;
        public StockController(IMapper map,
            IStockService StockService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _StockService = StockService;
        }
        [Authorize(Policy = "Stock.list")]
        public async Task<IActionResult> List()
        {
            var model = await _StockService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
                return View(_map.Map<List<StockListDto>>(model));
            }
            return View(new List<StockListDto>());

        }
        [HttpGet]
        [Authorize(Policy = "Stock.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.Stock = _map
                .Map<ICollection<StockListDto>>(await _StockService.GetAllAsync(x => !x.IsDeleted));
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "Stock.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StockAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Stock>(model);
                add.CreatedByUserId = GetSignInUserId();
                if (await _StockService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "Stock.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<StockUpdateDto>(await _StockService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.Stock = _map
                    .Map<ICollection<StockListDto>>(await _StockService.GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "Stock.update")]
        public async Task<IActionResult> Update(StockUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _StockService.FindByIdAsync(model.Id);
                var update = _map.Map<Stock>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _StockService.UpdateAsync(update);
                TempData["success"] = Messages.Update.Updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }

        [Authorize(Policy = "Stock.delete")]
        public async Task Delete(int id)
        {
            var delete = await _StockService.FindByIdAsync(id);
            delete.IsDeleted = true;
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            await _StockService.UpdateAsync(delete);
        }
    }
}
