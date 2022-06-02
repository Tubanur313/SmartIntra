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
        private readonly IMapper _mapper;
        private readonly INonWorkingDayService _nonWorkingDayService;
        private readonly INonWOrkingYearService _nonWorkingYearService;
        private static int _nonWorkingYearId;
        public NonWorkingDayController(UserManager<IntranetUser> userManager, INonWOrkingYearService nonWorkingYearService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, INonWorkingDayService nonWorkingDayService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _mapper = mapper;
            _nonWorkingDayService = nonWorkingDayService;
            _nonWorkingYearService = nonWorkingYearService;
        }
        [Authorize(Policy = "nonworkingday.list")]
        public async Task<IActionResult> List(int id)
        {
            if (id == 0 || (await _nonWorkingYearService.FindByIdAsync(id) == null)) return RedirectToAction("List", "NonWorkingYear");
            _nonWorkingYearId = id;
            IEnumerable<NonWorkingDayListDto> data = _mapper.Map<ICollection<NonWorkingDayListDto>>(await _nonWorkingDayService.GetAllIncCompAsync(x => !x.IsDeleted && x.NonWorkingYearId == id)).Select(x =>
                new NonWorkingDayListDto()
                {
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    Type = GetTypeNameByKey(x.Type),
                    DeleteByUserId = x.DeleteByUserId
                });

            return View(data);
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
        //    var department = _mapper.Map<ICollection<NonWorkingDayListDto>>(
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
                model.CreatedDate = DateTime.UtcNow.AddHours(4);
                model.IsDeleted = false;
                model.NonWorkingYearId = _nonWorkingYearId;
                
                await _nonWorkingDayService.AddAsync(_mapper.Map<NonWorkingDay>(model));
                return RedirectToAction("List", new { id = _nonWorkingYearId });
            }
        }

        [HttpGet]
        [Authorize(Policy = "nonworkingday.update")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.DayTypes = GetDayTypes();
         
            var listModel = _mapper.Map<NonWorkingDayUpdateDto>(await _nonWorkingDayService.FindByIdAsync(id));
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
                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List", new { id = _nonWorkingYearId });
            }
            else
            {
                var current = GetSignInUserId();
                
                model.UpdateDate = DateTime.UtcNow.AddHours(4);
                model.UpdateByUserId = current;

                await _nonWorkingDayService.UpdateAsync(_mapper.Map<NonWorkingDay>(model));
                return RedirectToAction("List", new { id = _nonWorkingYearId });
            }
        }

        [Authorize(Policy = "nonworkingday.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _mapper.Map<NonWorkingDayListDto>(await _nonWorkingDayService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _nonWorkingDayService.UpdateAsync(_mapper.Map<NonWorkingDay>(transactionModel));
            return Ok();
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
