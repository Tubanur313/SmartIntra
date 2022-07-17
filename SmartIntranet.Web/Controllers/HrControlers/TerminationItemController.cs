using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.TerminationItemDto;
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
                return View(model);
            }
            else
            {
                var current = GetSignInUserId();
                model.CreatedByUserId = current;
                model.CreatedDate = DateTime.Now;
                model.IsDeleted = false;
                await _terminationService.AddAsync(_map.Map<TerminationItem>(model));
                return RedirectToAction("List");
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
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
            else
            {
                var current = GetSignInUserId();
                
                model.UpdateDate = DateTime.Now;
                model.UpdateByUserId = current;

                await _terminationService.UpdateAsync(_map.Map<TerminationItem>(model));
                return RedirectToAction("List");
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
