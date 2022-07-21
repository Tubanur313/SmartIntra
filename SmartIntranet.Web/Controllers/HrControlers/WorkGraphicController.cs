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
using SmartIntranet.Core.Utilities.Messages;

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
        public async Task<IActionResult> List(string success, string error)
        {
            var model = _map.Map<ICollection<WorkGraphicListDto>>(await _workGraphicService.GetAllIncCompAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList();
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(model);
            }
            return View(new List<WorkGraphicListDto>());
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
            ViewBag.Names = JsonConvert.SerializeObject((await _workGraphicService.GetAllIncCompAsync(x => !x.IsDeleted)).Select(x => x.Name));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "workgraphic.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(WorkGraphicAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var current = GetSignInUserId();
                var add = _map.Map<WorkGraphic>(model);
                add.CreatedByUserId = current;
                add.IsDeleted = false;
                add.CreatedDate = DateTime.Now;
                if (await _workGraphicService.AddReturnEntityAsync(add) is null)
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
        }

        [HttpGet]
        [Authorize(Policy = "workgraphic.update")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Names = JsonConvert.SerializeObject((await _workGraphicService.GetAllIncCompAsync(x => x.Id != id && !x.IsDeleted)).Select(x => x.Name));
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
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var data = await _workGraphicService.FindByIdAsync(model.Id);
                var current = GetSignInUserId();
                var update = _map.Map<WorkGraphic>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                await _workGraphicService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "workgraphic.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<WorkGraphicListDto>(await _workGraphicService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _workGraphicService.UpdateAsync(_map.Map<WorkGraphic>(transactionModel));
        }
    }
}
