using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InfoControllers
{
    public class CategoryController : BaseIdentityController
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(IMapper map,
            ICategoryService categoryService, 
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager)
            :base(userManager,httpContextAccessor,signInManager,map)
        {
            _categoryService = categoryService;
        }
        [Authorize(Policy = "category.list")]
        public async Task<IActionResult> List()
        {
            var model = await _categoryService.GetAllAsync(x=>!x.IsDeleted);
            if (model.Count > 0)
            {
                return View(_map.Map<List<CategoryListDto>>(model));
            }
            return View(new List<CategoryListDto>());

        }
        [HttpGet]
        [Authorize(Policy = "category.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.category = _map
                .Map<ICollection<CategoryListDto>>(await _categoryService.GetAllAsync(x=>!x.IsDeleted));
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "category.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Category>(model);
                add.CreatedByUserId = GetSignInUserId();
                if (await _categoryService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                if (await _categoryService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "category.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<CategoryUpdateDto>(await _categoryService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.category = _map
                    .Map<ICollection<CategoryListDto>>(await _categoryService.GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "category.update")]
        public async Task<IActionResult> Update(CategoryUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _categoryService.FindByIdAsync(model.Id);
                var update = _map.Map<Category>(model);
                if (await _categoryService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _categoryService.UpdateAsync(update);
                TempData["success"] = Messages.Update.updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }

        [Authorize(Policy = "category.delete")]
        public async Task Delete(int id)
        {
            var delete = await _categoryService.FindByIdAsync(id);
            delete.IsDeleted = true;
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            await _categoryService.UpdateAsync(delete);
        }
    }
}
