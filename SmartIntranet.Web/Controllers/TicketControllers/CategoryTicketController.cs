using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{ [Authorize]
    public class CategoryTicketController : BaseIdentityController
    {
        private readonly ICategoryTicketService _CategoryTicketService;
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
            _CategoryTicketService = CategoryTicketService;
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Policy = "CategoryTicket.list")]
        public async Task<IActionResult> List()
        {
            var model = await _CategoryTicketService.GetAllIncludeAsync();
            if (model.Count > 0)
            {
                return View(_map.Map<List<CategoryTicketListDto>>(model));
            }
            return View(new List<CategoryTicketListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "CategoryTicket.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _CategoryTicketService.GetAllIncludeAsync());
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
                if (await _CategoryTicketService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                if (await _CategoryTicketService.AddReturnEntityAsync(add) is null)
                {
                    TempData["error"] =Messages.Add.notAdded;
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
        [Authorize(Policy = "CategoryTicket.update")]
        public async Task<IActionResult> Update(int Id)
        {
            var data = _map.Map<CategoryTicketUpdateDto>(await _CategoryTicketService.FindByIdAsync(Id));
            if (data == null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _CategoryTicketService.GetAllIncludeAsync());
            ViewBag.supporters = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "CategoryTicket.update")]
        public async Task<IActionResult> Update(CategoryTicketUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _CategoryTicketService.FindByIdAsync(model.Id);
                var update = _map.Map<CategoryTicket>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                if (await _CategoryTicketService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                await _CategoryTicketService.UpdateAsync(update);
                TempData["success"] = Messages.Update.updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }
        [Authorize(Policy = "CategoryTicket.delete")]
        public async Task Delete(int id)
        {
            var delete = await _CategoryTicketService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _CategoryTicketService.UpdateAsync(delete);
        }
    }
}
