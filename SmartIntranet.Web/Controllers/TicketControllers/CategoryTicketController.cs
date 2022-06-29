using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Extension;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CategoryTicketDto;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{ 
    [Authorize]
    public class CategoryTicketController : BaseIdentityController
    {
        private readonly ICategoryTicketService _categoryTicketService;
        private readonly IAppUserService _userService;
        public CategoryTicketController(
            IMapper map,
            ICategoryTicketService CategoryTicketService,
            IAppUserService userService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _categoryTicketService = CategoryTicketService;
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Policy = "CategoryTicket.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _categoryTicketService.GetAllIncludeAsync();
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<CategoryTicketListDto>>(model));
            }
            return View(new List<CategoryTicketListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "CategoryTicket.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.supporters = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "CategoryTicket.add")]
        public async Task<IActionResult> Add(CategoryTicketAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<CategoryTicket>(model);
                add.CreatedByUserId = GetSignInUserId();
                //if (await _categoryTicketService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                if (await _categoryTicketService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "CategoryTicket.update")]
        public async Task<IActionResult> Update(int Id)
        {
            var data = _map.Map<CategoryTicketUpdateDto>(await _categoryTicketService.FindByIdAsync(Id));
            if (data == null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            ViewBag.supporters = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "CategoryTicket.update")]
        public async Task<IActionResult> Update(CategoryTicketUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _categoryTicketService.FindByIdAsync(model.Id);
                var update = _map.Map<CategoryTicket>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.UtcNow;
                update.DeleteDate = data.DeleteDate;
                //if (await _categoryTicketService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                await _categoryTicketService.UpdateAsync(update);
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
        [Authorize(Policy = "CategoryTicket.delete")]
        public async Task Delete(int id)
        {
            var delete = await _categoryTicketService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.UtcNow;
            delete.IsDeleted = true;
            await _categoryTicketService.UpdateAsync(delete);
        }
        public async Task<IActionResult> GetCategoryTicketTree()
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _categoryTicketService
                .GetAllAsync(x => !x.IsDeleted));
            return new JsonResult(tree);
        }
    }
}
