using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class PositionController : BaseIdentityController
    {
        private readonly IPositionService _positionService;
        private readonly IDepartmentService _departmentService;
        private readonly ICompanyService _companyService;
        public PositionController(IPositionService PositionService,
            IDepartmentService departmentService,
            ICompanyService companyService,
            IMapper map,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _positionService = PositionService;
            _departmentService = departmentService;
            _companyService = companyService;
        }
        [HttpGet]
        [Authorize(Policy = "position.list")]
        public async Task<IActionResult> List()
        {
            var model = (await _positionService.GetAllIncludeAsync()).Where(x => !x.IsDeleted).ToList();
            if (model.Count > 0)
            {
                return View(_map.Map<List<PositionListDto>>(model));
            }
            return View(new List<PositionListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "position.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map
                .Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted == false));
            ViewBag.departments = _map
                .Map<List<DepartmentListDto>>(await _departmentService.GetAllAsync(x => x.IsDeleted == false));
            ViewBag.positions = _map
                .Map<List<PositionListDto>>(await _positionService.GetAllAsync(x => x.IsDeleted == false));

            return View();
        }
        [HttpPost]
        [Authorize(Policy = "position.add")]
        public async Task<IActionResult> Add(PositionAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Position>(model);
                add.CreatedByUserId = GetSignInUserId();
                if (await _positionService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "position.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<PositionUpdateDto>(await _positionService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.companies = _map
                .Map<List<CompanyListDto>>(await _companyService
                .GetAllAsync(x => x.IsDeleted == false));

            ViewBag.departments = _map
                .Map<List<DepartmentListDto>>(await _departmentService
                .GetAllAsync(x => x.IsDeleted == false
                && x.CompanyId == data.CompanyId));

            ViewBag.positions = _map
                .Map<List<PositionListDto>>(await _positionService
               .GetAllAsync(x => x.IsDeleted == false
                && x.CompanyId == data.CompanyId
                && x.DepartmentId == data.DepartmentId));

            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "position.update")]
        public async Task<IActionResult> Update(PositionUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _positionService.FindByIdAsync(model.Id);
                var update = _map.Map<Position>(model);

                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _positionService.UpdateAsync(update);
                TempData["success"] = "Yeniləndi";
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }
        [Authorize(Policy = "position.delete")]
        public async Task Delete(int id)
        {
            var delete = await _positionService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _positionService.UpdateAsync(delete);
        }

        [HttpGet]
        public async Task<IActionResult> GetPosition(int departmentId)
        {
            var position = await _positionService
                .GetAllAsync(x => x.IsDeleted == false
                && x.DepartmentId == departmentId);
            return Ok(position.Select(x => new { x.Id, x.Name }));
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartment(int companyId)
        {
            var department = await _departmentService
                .GetAllAsync(x => x.IsDeleted == false
                && x.CompanyId == companyId);
            return Ok(department.Select(x => new { x.Id, x.Name }));
        }
    }
}
