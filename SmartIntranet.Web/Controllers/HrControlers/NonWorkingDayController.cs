using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
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
    public class NonWorkingDayController : BaseIdentityController
    {
        private readonly INonWorkingDayService _nonWorkingDayService;
        private readonly INonWOrkingYearService _nonWorkingYearService;
        private static int _nonWorkingYearId;
        public NonWorkingDayController(UserManager<IntranetUser> userManager, INonWOrkingYearService nonWorkingYearService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, INonWorkingDayService nonWorkingDayService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _nonWorkingDayService = nonWorkingDayService;
            _nonWorkingYearService = nonWorkingYearService;
        }
        [Authorize(Policy = "nonworkingday.list")]
        public async Task<IActionResult> List(int id, string success, string error)
        {
            if (id == 0 || (await _nonWorkingYearService.FindByIdAsync(id) == null)) return RedirectToAction("List", "NonWorkingYear");
            _nonWorkingYearId = id;

            var model = _map.Map<ICollection<NonWorkingDayListDto>>(await _nonWorkingDayService.GetAllIncCompAsync(x => !x.IsDeleted && x.NonWorkingYearId == id));
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<ICollection<NonWorkingDayListDto>>(model).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .Select(x =>
                new NonWorkingDayListDto()
                {
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    Type = GetTypeNameByKey(x.Type),
                    DeleteByUserId = x.DeleteByUserId
                }).ToList());
            }
            return View(new List<NonWorkingDayListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "nonworkingday.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.DayTypes = GetDayTypes();
            return View();
        }

        //[HttpGet]
        //[Authorize]
        //public async Task<IActionResult> GetNonWorkingDay(int nonWorkingDayId)
        //{
        //    var department = _map.Map<ICollection<NonWorkingDayListDto>>(
        //        await _departmentService.GetAllAsync(x => x.IsDeleted  == false && x.CompanyId == nonWorkingDayId))
        //         .Select(x => new { x.Id, x.Name });

        //    return Ok(department);
        //}


        [HttpPost]
        [Authorize(Policy = "nonworkingday.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(NonWorkingDayAddDto model)
        {
            ViewBag.DayTypes = GetDayTypes();
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
                model.NonWorkingYearId = _nonWorkingYearId;

                await _nonWorkingDayService.AddAsync(_map.Map<NonWorkingDay>(model));
                return RedirectToAction("List", new { id = _nonWorkingYearId });
            }
        }

        [HttpGet]
        [Authorize(Policy = "nonworkingday.update")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.DayTypes = GetDayTypes();

            var listModel = _map.Map<NonWorkingDayUpdateDto>(await _nonWorkingDayService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "nonworkingday.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(NonWorkingDayUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List", new { id = _nonWorkingYearId });
            }
            else
            {
                var current = GetSignInUserId();

                model.UpdateDate = DateTime.Now;
                model.UpdateByUserId = current;

                await _nonWorkingDayService.UpdateAsync(_map.Map<NonWorkingDay>(model));
                return RedirectToAction("List", new { id = _nonWorkingYearId });
            }
        }

        [Authorize(Policy = "nonworkingday.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<NonWorkingDayListDto>(await _nonWorkingDayService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _nonWorkingDayService.UpdateAsync(_map.Map<NonWorkingDay>(transactionModel));
        }

        public List<DayType> GetDayTypes()
        {
            List<DayType> dayTypes = new List<DayType>();
            dayTypes.Add(new DayType { Key = "Holiday", Name = "Bayram" });
            dayTypes.Add(new DayType { Key = "Mourning", Name = "Matəm" });
            return dayTypes;
        }

        public string GetTypeNameByKey(string key)
        {
            return GetDayTypes().FirstOrDefault(x => x.Key == key).Name;
        }
    }
}
