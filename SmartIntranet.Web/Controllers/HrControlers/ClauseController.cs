using AutoMapper;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.Entities.Concrete.IntraHr;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.DTO.DTOs.AppUserDto;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class ClauseController : BaseIdentityController
    {
        private readonly IClauseService _clauseService;
        private readonly IUserCompService _userCompService;
        public ClauseController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IClauseService clauseService, IUserCompService userCompService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _clauseService = clauseService;
            _userCompService = userCompService;
        }
        [Authorize(Policy = "clause.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var userComp = await _userCompService.FirstOrDefault(GetSignInUserId());
            if (userComp is null)
            {
                return View(new List<ClauseListDto>());
            }
            var data = await _clauseService.GetAllIncCompAsync(x => !x.IsDeleted && x.CompanyId == userComp.CompanyId);
            var model = _map.Map<ICollection<ClauseListDto>>(data);
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                ViewBag.CompId = userComp.CompanyId;
                return View(_map.Map<ICollection<ClauseListDto>>(model).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
            }
            return View(new List<ClauseListDto>());
        }
        [HttpPost]
        [Authorize(Policy = "clause.list")]
        public async Task<IActionResult> List(int CompId)
        {
            ViewBag.CompId = CompId;
            var model = await _clauseService.GetAllIncCompAsync(x => !x.IsDeleted && x.CompanyId == CompId);
            return View(_map.Map<List<ClauseListDto>>(model));
        }
        [HttpGet]
        [Authorize(Policy = "clause.add")]
        public IActionResult Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_userCompService.GetAllIncAsync(GetSignInUserId()).Result.Select(x => x.Company).ToArray());
            return View();
        }



        [HttpPost]
        [Authorize(Policy = "clause.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ClauseAddDto model, IFormFile readyDoc)
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
                var add = _map.Map<Clause>(model);
                add.CreatedByUserId = current;
                add.CreatedDate = DateTime.Now;
                add.IsDeleted = false;
                add.IsDeletable = true;
                add.IsBackground = false;
                if (readyDoc != null && MimeTypeCheckExtension.İsDocument(readyDoc))
                {
                    add.FilePath = await AddFile($"wwwroot/clauseDocs-{model.CompanyId}/", readyDoc);
                }
                if (await _clauseService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "clause.update")]
        public async Task<IActionResult> Update(int id)
        {
            //ViewBag.company = await _companyService.FindByIdAsync((int)usr.CompanyId);
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_userCompService.GetAllIncAsync(GetSignInUserId()).Result.Select(x => x.Company).ToArray());
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
                var data = await _clauseService.FindByIdAsync(model.Id);
                if (readyDoc != null && MimeTypeCheckExtension.İsDocument(readyDoc))
                {
                    DeleteFile($"wwwroot/clauseDocs-{model.CompanyId}/", model.FilePath);
                    await AddFile($"wwwroot/clauseDocs-{model.CompanyId}/", readyDoc, model.FilePath);
                }

                var current = GetSignInUserId();
                var update = _map.Map<Clause>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                await _clauseService.UpdateAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "clause.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<ClauseListDto>(await _clauseService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            DeleteFile($"wwwroot/clauseDocs-{transactionModel.CompanyId}/", transactionModel.FilePath);
            await _clauseService.UpdateAsync(_map.Map<Clause>(transactionModel));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCompanyClauses(int companyId)
        {
            var clauses = _map.Map<ICollection<ClauseListDto>>(
                await _clauseService.GetAllAsync(x => !x.IsDeleted && !x.IsBackground && x.CompanyId == companyId));
            return Ok(clauses);
        }
    }
}
