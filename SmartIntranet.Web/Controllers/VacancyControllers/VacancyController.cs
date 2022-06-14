using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.VacancyDto;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class VacancyController : BaseIdentityController
    {
        private readonly IVacancyService _vacancyService;
        private readonly ICompanyService _companyService;

        public VacancyController(UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper map,
            IVacancyService vacancyService,
            ICompanyService companyService
            ) : base(userManager, httpContextAccessor, signInManager,map)
        {
            _vacancyService = vacancyService;
            _companyService = companyService;
        }
        [HttpGet]
        [Authorize(Policy = "vacancy.info")]
        public async Task<IActionResult> Info()
        {
            var vacancies = _map.Map<ICollection<VacancyUpdateDto>>(await _vacancyService.ShowAllWithIncludeAsync());
            foreach (var vc in vacancies)
            {
                if (DateTime.Now > vc.EndDate)
                {
                    vc.IsDeleted = true;
                    await _vacancyService.UpdateModifiedAsync(_map.Map<Vacancy>(vc));
                }
            }
            var model = _map.Map<ICollection<VacancyListDto>>(await _vacancyService.ShowAllWithIncludeAsync());
            if (model.Count > 0)
            {
                return View(_map.Map<List<VacancyListDto>>(model));
            }
            return View(new List<VacancyListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "vacancy.detail")]
        public IActionResult Detail(int id)
        {
            return View(_map.Map<VacancyListDto>(_vacancyService.FindByIdIncAsync(id)));
        }
        [HttpGet]
        [Authorize(Policy = "category.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _vacancyService.GetAllWithIncludeAsync();
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<VacancyListDto>>(model));
            }
            return View(new List<VacancyListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "category.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map
                .Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));

            return View();
        }
        [HttpPost]
        [Authorize(Policy = "vacancy.add")]
        public async Task<IActionResult> Add(VacancyAddDto model)
        {
            if (ModelState.IsValid)
            {
                var image = await _companyService.FindByIdAsync(model.CompanyId);
                var add = _map.Map<Vacancy>(model);
                add.StartDate = DateTime.Now;
                add.ImagePath = image.LogoPath;
                add.CreatedByUserId = GetSignInUserId();
                if (await _vacancyService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "vacancy.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<VacancyUpdateDto>(await _vacancyService.FindByIdAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            ViewBag.companies = _map
                .Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "vacancy.update")]
        public async Task<IActionResult> Update(VacancyAddDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _vacancyService.FindByIdAsync(model.Id);
                var update = _map.Map<Vacancy>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                if (await _vacancyService.UpdateReturnEntityAsync(update) is null)
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Update.notUpdated
                    });
                }
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
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
        [Authorize(Policy = "vacancy.delete")]
        public async Task Delete(int id)
        {
            var delete = await _vacancyService.FindByIdAsync(id);
            delete.IsDeleted = true;
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            await _vacancyService.UpdateAsync(delete);
        }
    }
}
