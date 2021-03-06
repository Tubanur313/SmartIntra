using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class NonWorkingYearController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        private readonly INonWOrkingYearService _nonWorkingYearService;
        public NonWorkingYearController(UserManager<IntranetUser> userManager, INonWOrkingYearService nonWorkingYearService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, INonWorkingDayService nonWorkingDayService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _mapper = mapper;
            _nonWorkingYearService = nonWorkingYearService;
        }

        [Authorize(Policy = "nonworkingyear.list")]
        public async Task<IActionResult> List()
        {
            return View(_mapper.Map<ICollection<NonWorkingYearListDto>>(await _nonWorkingYearService.GetAllIncCompAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
        }

        [HttpGet]
        [Authorize(Policy = "nonworkingyear.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.Years = JsonConvert.SerializeObject((await _nonWorkingYearService.GetAllIncCompAsync(x => x.DeleteByUserId == null)).Select(x => x.Year));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "nonworkingyear.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(NonWorkingYearAddDto model)
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
                if ((await _nonWorkingYearService.GetAllAsync()).Any(x => x.Year == model.Year && x.DeleteByUserId == null))
                {
                    ModelState.AddModelError("Year", "Bu il artıq mövcuddur");
                    return RedirectToAction("Add");
                }
                await _nonWorkingYearService.AddAsync(_mapper.Map<NonWorkingYear>(model));
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetNonWorkingYear(int nonWorkingYearId)
        {
            var nonWorkingYear = _mapper.Map<ICollection<NonWorkingYearListDto>>(
                await _nonWorkingYearService.GetAllAsync(x => x.IsDeleted  == false && x.Id == nonWorkingYearId))
                 .Select(x => new { x.Id, x.Year });

            return Ok(nonWorkingYear);
        }


        [HttpGet]
        [Authorize(Policy = "nonworkingyear.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _mapper.Map<NonWorkingYearUpdateDto>(await _nonWorkingYearService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            ViewBag.Years = JsonConvert.SerializeObject((await _nonWorkingYearService.GetAllIncCompAsync(x => x.Id != id && x.DeleteByUserId == null)).Select(x => x.Year));
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "nonworkingyear.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(NonWorkingYearUpdateDto model)
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
                await _nonWorkingYearService.UpdateAsync(_mapper.Map<NonWorkingYear>(model));
                return RedirectToAction("List");
            }
        }

        [Authorize(Policy = "nonworkingyear.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _mapper.Map<NonWorkingYearListDto>(await _nonWorkingYearService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _nonWorkingYearService.UpdateAsync(_mapper.Map<NonWorkingYear>(transactionModel));
            return Ok();
        }
    }
}
