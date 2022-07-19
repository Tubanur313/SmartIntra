using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Business.Extension;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;

namespace SmartIntranet.Web.Controllers
{
    public class CompanyController : BaseIdentityController
    {
        private readonly ICompanyService _companyService;
        private readonly IAppUserService _appUserService;
        private readonly IFileService _upload;
        public CompanyController(
            UserManager<IntranetUser> userManager,
            IAppUserService appUserService,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper mapper,
            IFileService upload,
            ICompanyService companyService
            ) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _companyService = companyService;
            _appUserService = appUserService;
            _upload = upload;
        }

        [Authorize(Policy = "company.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _companyService.GetAllAsync(x => !x.IsDeleted);
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<List<CompanyListDto>>(model)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToList());
            }

            return View(new List<CompanyListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "company.add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyTree()
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _companyService
                .GetAllAsync(x => !x.IsDeleted));
            return new JsonResult(tree);
        }
        [HttpPost]
        [Authorize(Policy = "company.add")]
        public async Task<IActionResult> Add(CompanyAddDto model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                if (!(logo is null) && logo.FileName != "logoDefault.png")
                {
                    if (!MimeTypeCheckExtension.İsImage(logo))
                    {
                        TempData["error"] = Messages.Error.wrongFormat;
                    }
                    else
                    {
                        model.LogoPath =await _upload.UploadResizedImg(logo, "wwwroot/logo/");
                    }
                }
                //if (await _companyService.AnyAsync(x => x.Name.ToUpper()
                //.Contains(model.Name.ToUpper()) && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                var add = _map.Map<Company>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.Now;
                if (await _companyService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "company.ajaxadd")]
        public async Task<IActionResult> AjaxAdd(AjaxCompanyAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Company>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.CreatedDate = DateTime.Now;
                if (await _companyService.AddReturnEntityAsync(add) is null)
                {
                    return BadRequest(Messages.Add.notAdded);
                }
                var list = await _companyService.GetAllAsync(x => x.IsDeleted == false);
                if (list.Count > 0)
                {
                    return Ok(_map.Map<List<CompanyListDto>>(list).Select(x => new
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
        [Authorize(Policy = "company.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<CompanyUpdateDto>(await _companyService.FindByIdAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            ViewBag.Leader = _map.Map<ICollection<AppUserListDto>>(await _appUserService.GetAllIncludeAsync(x => !x.IsDeleted && x.CompanyId == id));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "company.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CompanyUpdateDto model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                var data = await _companyService.FindByIdAsync(model.Id);
                if (!(logo is null) && logo.FileName != "logoDefault.png")
                {
                    _upload.Delete(data.LogoPath, "wwwroot/logo/");
                    model.LogoPath = await _upload.UploadResizedImg(logo, "wwwroot/logo/");
                }
                else if (!(logo is null))
                {
                    model.LogoPath = "logoDefault.png";
                }
                else
                {
                    model.LogoPath = data.LogoPath;
                }
                var update = _map.Map<Company>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                //if (await _companyService.AnyAsync(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) && x.Id != model.Id && !x.IsDeleted))
                //{
                //    return RedirectToAction("List", new
                //    {
                //        error = Messages.Error.sameName
                //    });
                //}
                await _companyService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            return RedirectToAction("List", new
            {
                error = Messages.Error.notComplete
            });


        }
        [Authorize(Policy = "company.delete")]
        public async Task Delete(int id)
        {
            var delete = await _companyService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _companyService.UpdateAsync(delete);
        }

    }
}
