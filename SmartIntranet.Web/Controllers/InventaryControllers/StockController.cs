using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.FileUploader;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockImageDto;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InventaryControllers
{
    public class StockController : BaseIdentityController
    {

        private readonly IStockService _stockService;
        private readonly IStockCategoryService _stockCategoryService;
        private readonly IStockImageService _stockImageService;
        private readonly IAppUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IFileManager _upload;
        public StockController(IMapper map,
            IStockService StockService,
            IStockCategoryService stockCategoryService,
            UserManager<IntranetUser> userManager,
            IAppUserService userService,
            ICompanyService companyService,
            IHttpContextAccessor httpContextAccessor,
            IStockImageService stockImageService,
            IFileManager upload,
            SignInManager<IntranetUser> signInManager)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _stockService = StockService;
            _stockCategoryService = stockCategoryService;
            _userService = userService;
            _companyService = companyService;
            _stockImageService = stockImageService;
            _upload = upload;
        }
        [Authorize(Policy = "stock.list")]
        public async Task<IActionResult> List()
        {
            var model = await _stockService.GetStockAllIncludeAsync();
            if (model.Count > 0)
            {
                return View(_map.Map<List<StockListDto>>(model));
            }
            return View(new List<StockListDto>());

        }
        [HttpGet]
        [Authorize(Policy = "stock.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService
            .GetAllAsync(x => !x.IsDeleted));
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "stock.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StockAddDto model, List<IFormFile> uploads)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Stock>(model);
                add.CreatedByUserId = GetSignInUserId();
                if (await _stockService.AddReturnEntityAsync(add) is null)
                {
                    TempData["error"] = Messages.Add.notAdded;
                    return RedirectToAction("List");
                }
                foreach (var upload in uploads)
                {
                    if (MimeTypeCheckExtension.İsImage(upload))
                    {
                        string folder = "/stock/";
                        string name = _upload.UploadResizedImg(upload, "wwwroot" + folder);
                        StockImageAddDto dto = new StockImageAddDto
                        {
                            Name = name,
                            Path = HttpContext.Request.Host.Value + folder + name,
                            StockId = add.Id
                        };
                        var photo = _map.Map<StockImage>(dto);
                        photo.CreatedByUserId = GetSignInUserId();
                        await _stockImageService.AddAsync(photo);
                    }
                    else
                    {
                        TempData["success"] = Messages.Add.Added;
                        TempData["error"] = $"{upload.ContentType.GetType()} formatı uyğun format deyil";
                        return RedirectToAction("List");
                    }
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
        [Authorize(Policy = "stock.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<StockUpdateDto>(await _stockService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService
            .GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "stock.update")]
        public async Task<IActionResult> Update(StockUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _stockService.FindByIdAsync(model.Id);
                var update = _map.Map<Stock>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _stockService.UpdateAsync(update);
                TempData["success"] = Messages.Update.updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }

        [Authorize(Policy = "stock.delete")]
        public async Task Delete(int id)
        {
            var delete = await _stockService.FindByIdAsync(id);
            delete.IsDeleted = true;
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            await _stockService.UpdateAsync(delete);
        }
    }
}
