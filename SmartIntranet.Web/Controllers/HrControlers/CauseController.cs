using AutoMapper;
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

namespace SmartIntranet.Web.Controllers
{
    public class CauseController : BaseIdentityController
    {
        private readonly ICauseService _causeService;
        public CauseController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, ICauseService causeService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _causeService = causeService;
        }
        [Authorize(Policy = "cause.list")]
        public async Task<IActionResult> List()
        {
            IEnumerable<CauseListDto> data = _map.Map<ICollection<CauseListDto>>(await _causeService.GetAllIncAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList();
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var current = GetSignInUserId();
                model.CreatedByUserId = current;
                model.CreatedDate = DateTime.UtcNow.AddHours(4);
                model.IsDeleted = false;
                await _causeService.AddAsync(_map.Map<Cause>(model));
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        [Authorize(Policy = "cause.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<CauseUpdateDto>(await _causeService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "cause.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CauseUpdateDto model)
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

                await _causeService.UpdateAsync(_map.Map<Cause>(model));
                return RedirectToAction("List");
            }
        }

        [Authorize(Policy = "cause.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _map.Map<CauseListDto>(await _causeService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _causeService.UpdateAsync(_map.Map<Cause>(transactionModel));
            return Ok();
        }
    }
}
