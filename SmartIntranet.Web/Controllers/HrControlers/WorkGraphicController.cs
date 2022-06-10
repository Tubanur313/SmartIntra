using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class WorkGraphicController : BaseIdentityController
    {
        private readonly IWorkGraphicService _workGraphicService;
        private readonly INonWOrkingYearService _nonWorkingYearService;
        public WorkGraphicController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IWorkGraphicService workGraphicService, INonWOrkingYearService nonWorkingYearService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _workGraphicService = workGraphicService;
            _nonWorkingYearService = nonWorkingYearService;
        }

        [Authorize(Policy = "workgraphic.list")]
        public async Task<IActionResult> List()
        {

            return View(_map.Map<ICollection<WorkGraphicListDto>>(await _workGraphicService.GetAllIncCompAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
        }

        [HttpGet]
        [Authorize(Policy = "workgraphic.detail")]
        public async Task<IActionResult> Detail()
        {
            
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "workgraphic.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.years = _map.Map<ICollection<NonWorkingYear>>(await _nonWorkingYearService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.Names = JsonConvert.SerializeObject((await _workGraphicService.GetAllIncCompAsync(x => x.DeleteByUserId == null)).Select(x => x.Name));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "workgraphic.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(WorkGraphicAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var current = GetSignInUserId();
                model.CreatedByUserId = current;
                model.IsDeleted = false;
                await _workGraphicService.AddAsync(_map.Map<WorkGraphic>(model));
                return RedirectToAction("List");

            }
        }

        [HttpGet]
        [Authorize(Policy = "workgraphic.update")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Names = JsonConvert.SerializeObject((await _workGraphicService.GetAllIncCompAsync(x => x.Id != id && x.DeleteByUserId == null)).Select(x => x.Name));
            var listModel = _map.Map<WorkGraphicUpdateDto>(await _workGraphicService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            ViewBag.years = _map.Map<ICollection<NonWorkingYear>>(await _nonWorkingYearService.GetAllAsync(x => x.IsDeleted  == false));
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "workgraphic.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(WorkGraphicUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
            else
            {
                var current = GetSignInUserId();
             
                model.UpdateDate = DateTime.UtcNow.AddHours(4);
                model.UpdateByUserId = current;
                await _workGraphicService.UpdateAsync(_map.Map<WorkGraphic>(model));
                return RedirectToAction("List");
            }
        }

        [Authorize(Policy = "workgraphic.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _map.Map<WorkGraphicListDto>(await _workGraphicService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _workGraphicService.UpdateAsync(_map.Map<WorkGraphic>(transactionModel));
            return Ok();

        }


    }
}
