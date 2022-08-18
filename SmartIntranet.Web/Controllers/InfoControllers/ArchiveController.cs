using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Extension;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Intranet.Archives;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.ArchiveDto;
using SmartIntranet.Entities.Concrete.Intranet.Archives;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InfoControllers
{
    public class ArchiveController : BaseIdentityController
    {
        private readonly IUserCompService _userCompService;
        private readonly IArchiveService _archiveService;
        private readonly IFileService _upload;
        private readonly IDepartmentService _departmentService;
        private readonly ICompanyService _companyService;
        private readonly IAppUserService _userService;
        public ArchiveController(
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IFileService upload,
            IArchiveService archiveService,
            IDepartmentService departmentService,
            ICompanyService companyService,
            IAppUserService userService,
            IUserCompService userCompService,
            IMapper map
            )
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _upload = upload;
            _archiveService = archiveService;
            _departmentService = departmentService;
            _companyService = companyService;
            _userService = userService;
            _userCompService = userCompService;
        }
        [HttpGet]
        [Authorize(Policy = "archive.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            //var userComp = await _userCompService.FirstOrDefault(GetSignInUserId());
            var user = await _userService.GetAsync(x => x.Id == GetSignInUserId());
            if (user is null || user.CompanyId == null)
            {
                return View(new List<ArchiveListDto>());
            }
            else
            {
                var model = await _archiveService.GetAllIncAsync((int)user.CompanyId);
                if (model.Count > 0)
                {
                    TempData["success"] = success;
                    TempData["error"] = error;
                    return View(_map.Map<List<ArchiveListDto>>(model));
                }
                return View(new List<ArchiveListDto>());
            }

        }
        [HttpGet]
        [Authorize(Policy = "archive.add")]
        public async Task<IActionResult> AddAsync()
        {
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "archive.add")]
        public async Task<IActionResult> Add(ArchiveAddDto model, IFormFile faqFile)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Archive>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.Now;
                if (faqFile != null)
                {
                    add.File = await _upload.Upload(faqFile, "wwwroot/archive");
                }
                if (await _archiveService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "archive.update")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            var data = _map.Map<ArchiveUpdateDto>(await _archiveService.FindByIdAsync(id));
            if (data is null)
                return RedirectToAction("List", new { error = Messages.Error.notFound });
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "archive.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ArchiveUpdateDto model, IFormFile faqFile)
        {
            if (ModelState.IsValid)
            {
                var data = await _archiveService.FindByIdAsync(model.Id);
                var update = _map.Map<Archive>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                if (faqFile != null)
                {
                    _upload.Delete(data.File, "wwwroot/archive");
                    update.File = await _upload.Upload(faqFile, "wwwroot/archive");
                }

                await _archiveService.UpdateAsync(update);
                if (await _archiveService.UpdateReturnEntityAsync(update) is null)
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

        [Authorize(Policy = "archive.delete")]
        public async Task Delete(int id)
        {
            var delete = await _archiveService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _archiveService.UpdateAsync(delete);
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
    }
}
