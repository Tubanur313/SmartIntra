using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.FileUploader;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.DTO.DTOs.NewsDto;
using SmartIntranet.DTO.DTOs.NewsFileDto;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InfoControllers
{
    public class NewsController : BaseIdentityController
    {
        private readonly INewsService _newsService;
        private readonly INewsFileService _newsfileService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryNewsService _categoryNewsService;
        private readonly IFileManager _upload;

        public NewsController
            (
            IMapper map,
            IFileManager upload,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            INewsService newsService,
            INewsFileService newsfileService,
            ICategoryNewsService categoryNewsService,
            ICategoryService categoryService
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _upload = upload;
            _newsService = newsService;
            _newsfileService = newsfileService;
            _categoryNewsService = categoryNewsService;
            _categoryService = categoryService;
        }
        [Authorize(Policy = "news.info")]
        public async Task<IActionResult> Info()
        {
            var model = await _newsService.GetAllWithIncludeNonDeleteAsync();
            if (model.Count > 0)
            {
                return View(_map.Map<List<NewsListDto>>(model));
            }
            return View(new List<NewsListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "news.list")]
        public async Task<IActionResult> List()
        {
            var model = await _newsService.GetAllWithIncludeAsync();
            if (model.Count > 0)
            {
                return View(_map.Map<List<NewsListDto>>(model));
            }
            return View(new List<NewsListDto>());
        }

        [Authorize(Policy = "news.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.categories = _map
                .Map<ICollection<CategoryListDto>>(await _categoryService.GetAllAsync(x => !x.IsDeleted));

            return View();
        }
        [HttpPost]
        [Authorize(Policy = "news.add")]
        public async Task<IActionResult> Add(NewsAddDto model, List<IFormFile> uploads)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<News>(model);
                add.CreatedByUserId = GetSignInUserId();
                var result = await _newsService.AddReturnEntityAsync(add);
                if (result.Id == 0)
                {
                    TempData["error"] = Messages.Add.notAdded;
                    return RedirectToAction("List");
                }

                if (uploads.Count > 0)
                {
                    foreach (var upload in uploads)
                    {
                        if (!MimeTypeCheckExtension.İsImage(uploads))
                        {
                            TempData["error"] = Messages.Error.wrongFormat;
                        }
                        else
                        {
                            NewsFileAddDto file = new NewsFileAddDto()
                            {
                                Name = _upload.UploadResizedImg(upload, "wwwroot/news/"),
                                NewsId = result.Id
                            };
                            await _newsfileService.AddAsync(_map.Map<NewsFile>(file));
                        }
                    }
                }
                if (model.CategoriesId.Count > 0)
                {
                    foreach (int categoryId in model.CategoriesId)
                    {
                        CategoryNewsAddDto confirm = new CategoryNewsAddDto
                        {
                            CategoryId = categoryId,
                            NewsId = result.Id
                        };
                        var map = _map.Map<CategoryNews>(confirm);
                        map.CreatedByUserId = GetSignInUserId();
                        var confirmers = await _categoryNewsService
                        .AddReturnEntityAsync(map);
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
        [Authorize(Policy = "news.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<NewsUpdateDto>(await _newsService.FindByIdIncludeAllAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            ViewBag.categories = _map
                .Map<ICollection<CategoryListDto>>(await _categoryService.GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "news.update")]
        public async Task<IActionResult> Update(NewsAddDto model, List<IFormFile> uploads)
        {
            if (ModelState.IsValid)
            {
                var data = await _newsService.FindByIdAsync(model.Id);
                var update = _map.Map<News>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                var result = await _newsService.UpdateReturnEntityAsync(update);
                if (result.Id == 0)
                {
                    TempData["error"] = Messages.Add.notAdded;
                    return RedirectToAction("List");
                }
                if (uploads.Count > 0)
                {
                    foreach (var upload in uploads)
                    {
                        if (!MimeTypeCheckExtension.İsImage(uploads))
                        {
                            TempData["error"] = Messages.Error.wrongFormat;
                        }
                        else
                        {
                            NewsFileAddDto file = new NewsFileAddDto()
                            {
                                Name = _upload.UploadResizedImg(upload, "wwwroot/news/"),
                                NewsId = result.Id
                            };
                            await _newsfileService.AddAsync(_map.Map<NewsFile>(file));
                        }
                    }
                }
                if (model.CategoriesId.Count > 0)
                {
                    foreach (int categoryId in model.CategoriesId)
                    {
                        if (!await _categoryNewsService
                            .AnyAsync(x => x.NewsId == result.Id && x.CategoryId == categoryId))
                        {
                            CategoryNewsAddDto confirm = new CategoryNewsAddDto
                            {
                                CategoryId = categoryId,
                                NewsId = result.Id
                            };
                            var map = _map.Map<CategoryNews>(confirm);
                            map.CreatedByUserId = GetSignInUserId();
                            var confirmers = await _categoryNewsService
                            .AddReturnEntityAsync(map);
                        }
                    }
                }
                TempData["success"] = Messages.Update.Updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }
    }
}
