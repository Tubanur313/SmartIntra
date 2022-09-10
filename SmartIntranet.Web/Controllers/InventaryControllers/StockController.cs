using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDiscussDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockImageDto;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Membership;

namespace SmartIntranet.Web.Controllers.InventaryControllers
{
    public class StockController : BaseIdentityController
    {

        private readonly IStockService _stockService;
        private readonly IStockDiscussService _stockDiscussService;
        private readonly IStockCategoryService _stockCategoryService;
        private readonly IStockImageService _stockImageService;
        private readonly IAppUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IFileService _upload;
        public StockController(IMapper map,
            IStockService StockService,
            IStockCategoryService stockCategoryService,
            UserManager<IntranetUser> userManager,
            IAppUserService userService,
            ICompanyService companyService,
            IStockDiscussService stockDiscussService,
            IHttpContextAccessor httpContextAccessor,
            IStockImageService stockImageService,
            IFileService upload,
            SignInManager<IntranetUser> signInManager)
            : base(userManager, httpContextAccessor, signInManager, map)
        {
            _stockService = StockService;
            _stockDiscussService = stockDiscussService;
            _stockCategoryService = stockCategoryService;
            _userService = userService;
            _companyService = companyService;
            _stockImageService = stockImageService;
            _upload = upload;
        }
        [Authorize(Policy = "stock.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _stockService.GetStockAllIncludeAsync();
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
                ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
                ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
                return View(_map.Map<List<StockListDto>>(model));
            }
            ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
            return View(new List<StockListDto>());
        }
        [HttpPost]
        [Authorize(Policy = "stock.list")]
        public async Task<IActionResult> List(int stockCategoryId, int companyId, StockStatus StockStatus)
        {
            List<Stock> model = await _stockService.FilterByStatusCategCompAsync(stockCategoryId, companyId, StockStatus);

            if (model.Count > 0)
            {
                ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
                ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
                return View(_map.Map<List<StockListDto>>(model));
            }
            ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.companies = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
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
                add.CreatedDate = DateTime.Now;
                if (await _stockService.AddReturnEntityAsync(add) is null)
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Add.notAdded
                    });
                }
                foreach (var upload in uploads)
                {
                    if (MimeTypeCheckExtension.İsImage(upload))
                    {
                        string folder = "/stock/";
                        string name = await _upload.UploadResizedImg(upload, "wwwroot" + folder);
                        StockImageAddDto dto = new StockImageAddDto
                        {
                            Name = name,
                            Path = HttpContext.Request.Host.Value + folder + name,
                            StockId = add.Id
                        };
                        var photo = _map.Map<StockImage>(dto);
                        photo.CreatedByUserId = GetSignInUserId();
                        photo.CreatedDate = DateTime.Now;
                        await _stockImageService.AddAsync(photo);
                    }
                    else
                    {
                        return RedirectToAction("List", new
                        {
                            success = Messages.Add.Added,
                            error = $"{upload.ContentType.GetType()} formatı uyğun format deyil"
                        });
                    }
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
        [Authorize(Policy = "stock.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<StockUpdateDto>(await _stockService.FindByIdAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            ViewBag.StockCategories = _map.Map<List<StockCategoryListDto>>(await _stockCategoryService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService
                .GetAllIncludeAsync());
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

                if (await _stockService.UpdateReturnEntityAsync(update) is null)
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

        [HttpGet]
        [Authorize(Policy = "stock.detail")]
        public async Task<IActionResult> Detail(int id)
        {
            var data = _map.Map<StockInfoDto>(await _stockService.FindByIdIncludeAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.stockDiscCount = _stockDiscussService.GetAllAsync(x => x.StockId == id).Result.Count;
            return View(data);
        }
        [Authorize(Policy = "stock.discuss")]
        public async Task<IActionResult> Discuss(StockDiscussAddDto model)
        {
            var add = _map.Map<StockDiscuss>(model);
            add.CreatedByUserId = GetSignInUserId();
            add.IntranetUserId = GetSignInUserId();
            add.CreatedDate = DateTime.Now;
            var result = await _stockDiscussService.AddReturnEntityAsync(add);
            var count = await _stockDiscussService.GetAllAsync(x => x.StockId == result.StockId);

            var discuss = _map.Map<StockDiscussListDto>(await _stockDiscussService.GetAllIncludeAsync(result.Id));
            return Ok(new
            {
                fulname = _map.Map<AppUserDetailsDto>(discuss.IntranetUser).ToString(),
                comment = discuss.Content,
                date = discuss.CreatedDate.Value.ToString("dd.MM.yyyy HH:mm:ss"),
                count = count.Count
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetDiscuss(int stockId)
        {
            var discuss = _map
                .Map<List<StockDiscussListSecondDto>>(await _stockDiscussService.GetAllByTicketAsync(stockId));
            return PartialView("_stockDiscuss", discuss);
        }

        [HttpGet]
        [Authorize(Policy = "stock.GetPhoto")]
        public async Task<IActionResult> GetPhoto(int stockId)
        {
            var photo = _map.Map<List<StockImageListDto>>(await _stockImageService.GetAllByStockAsync(stockId));
            return PartialView("_stockPhoto", photo);
        }
        [HttpPost]
        [Authorize(Policy = "stock.load")]
        public async Task<IActionResult> Load(int Id, IFormFile[] files)
        {
            foreach (var upload in files)
            {
                if (MimeTypeCheckExtension.İsImage(upload))
                {
                    string folder = "/stock/";
                    string name = await _upload.UploadResizedImg(upload, "wwwroot" + folder);
                    StockImageAddDto dto = new StockImageAddDto
                    {
                        Name = name,
                        Path = HttpContext.Request.Host.Value + folder + name,
                        StockId = Id
                    };
                    var photo = _map.Map<StockImage>(dto);
                    photo.CreatedByUserId = GetSignInUserId();
                    photo.CreatedDate = DateTime.Now;
                    await _stockImageService.AddAsync(photo);
                }
                else
                {
                    return Ok($"{upload.ContentType.GetType()} formatı uyğun format deyil");
                }
            }
            return Ok();
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