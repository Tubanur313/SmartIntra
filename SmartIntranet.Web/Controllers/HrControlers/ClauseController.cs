using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
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
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;

namespace SmartIntranet.Web.Controllers
{
    public class ClauseController : BaseIdentityController
    {
        private readonly IClauseService _clauseService;
        public ClauseController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IClauseService clauseService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _clauseService = clauseService;
        }
        [Authorize(Policy = "clause.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            TempData["success"] = success;
            TempData["error"] = error;
            IEnumerable<ClauseListDto> data = _map.Map<ICollection<ClauseListDto>>(await _clauseService.GetAllIncCompAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList();
            return View(data);
        }

        [HttpGet]
        [Authorize(Policy = "clause.add")]
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        [Authorize(Policy = "clause.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ClauseAddDto model, IFormFile readyDoc)
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
                model.IsDeletable = true;
                model.IsBackground = false;
                if (readyDoc != null && MimeTypeCheckExtension.İsDocument(readyDoc))
                {
                    model.FilePath = await AddFile("wwwroot/clauseDocs/", readyDoc);
                }
                await _clauseService.AddAsync(_map.Map<Clause>(model));
                return RedirectToAction("List", new
                {
                    success = Messages.Add.Added
                });
            }
        }

        [HttpGet]
        [Authorize(Policy = "clause.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<ClauseUpdateDto>(await _clauseService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "clause.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ClauseUpdateDto model, IFormFile readyDoc)
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
                if (readyDoc != null && MimeTypeCheckExtension.İsDocument(readyDoc))
                {
                    DeleteFile("wwwroot/clauseDocs/", model.FilePath);
                    await AddFile("wwwroot/clauseDocs/", readyDoc, model.FilePath);
                }
                var current = GetSignInUserId();

                model.UpdateDate = DateTime.Now;
                model.UpdateByUserId = current;

                await _clauseService.UpdateAsync(_map.Map<Clause>(model));
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "clause.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _map.Map<ClauseListDto>(await _clauseService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            DeleteFile("wwwroot/clauseDocs/", transactionModel.FilePath);
            await _clauseService.UpdateAsync(_map.Map<Clause>(transactionModel));
            return Ok();
        }
    }
}
