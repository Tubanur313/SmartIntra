using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Extension;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class DepartmentController : BaseIdentityController
    {
        private readonly IDepartmentService _departmentService;
        private readonly ICompanyService _companyService;
        public DepartmentController(IMapper map, IDepartmentService departmentService,
            ICompanyService companyService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _departmentService = departmentService;
            _companyService = companyService;
        }
        [HttpGet]
        [Authorize(Policy = "department.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _departmentService.GetAllIncludeAsync();
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<DepartmentListDto>>(model));
            }
            return View(new List<DepartmentListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "department.add")]
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> GetCompanyTree()
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _companyService
                .GetAllAsync(x => !x.IsDeleted));
            return new JsonResult(tree);
        }
        public async Task<IActionResult> GetDepartmentTree(int companyId)
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _departmentService
                .GetAllAsync(x => x.CompanyId == companyId && !x.IsDeleted));
            return new JsonResult(tree);
        }
        [HttpPost]
        [Authorize(Policy = "department.add")]
        public async Task<IActionResult> Add(DepartmentAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Department>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.UtcNow;
                if (await _departmentService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                if (await _departmentService.AddReturnEntityAsync(add) is null)
                {
                    return RedirectToAction("List", new
                    {
                        error =  Messages.Add.notAdded
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
        [Authorize(Policy = "department.ajaxadd")]
        public async Task<IActionResult> AjaxAdd(DepartmentAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Department>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.UtcNow;
                if (await _departmentService.AddReturnEntityAsync(add) is null)
                {
                    return BadRequest(Messages.Add.notAdded);
                }
                var list = await _departmentService.GetAllAsync(x => x.IsDeleted == false);
                if (list.Count > 0)
                {
                    return Ok(_map.Map<List<DepartmentListDto>>(list).Select(x => new
                    {
                        id = x.Id,
                        name = x.Name,
                    }));
                }
                return Ok(Messages.Add.notAdded);
            }
            else
            {
                return BadRequest(Messages.Error.notComplete);
            }
        }
        [HttpGet]
        [Authorize(Policy = "department.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<DepartmentUpdateDto>(await _departmentService.FindByIdAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "department.update")]
        public async Task<IActionResult> Update(DepartmentUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _departmentService.FindByIdAsync(model.Id);
                var update = _map.Map<Department>(model);

                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.UtcNow;
                update.DeleteDate = data.DeleteDate;
                if (await _departmentService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Error.sameName
                    });
                }
                if (await _departmentService.UpdateReturnEntityAsync(update) is null)
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
        [Authorize(Policy = "department.delete")]
        public async Task Delete(int id)
        {
            var delete = await _departmentService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.UtcNow;
            delete.IsDeleted = true;
            await _departmentService.UpdateAsync(delete);
        }
    }
}
