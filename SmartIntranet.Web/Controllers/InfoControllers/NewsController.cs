using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.DTO.DTOs.NewsDto;
using SmartIntranet.DTO.DTOs.NewsFileDto;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.InfoControllers
{
    public class NewsController : BaseIdentityController
    {
        private readonly INewsService _newsService;
        private readonly INewsFileService _newsfileService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryNewsService _categoryNewsService;
        private readonly IFileService _upload;

        public NewsController
            (
            IMapper map,
            IFileService upload,
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
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _newsService.GetAllWithIncludeAsync();
            if (model.Count > 0)
            {
                TempData["success"] = success;
                TempData["error"] = error;
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
                add.AppUserId = GetSignInUserId();
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
                        if (await _categoryNewsService.AddReturnEntityAsync(map) is null)
                        {
                            return RedirectToAction("List", new
                            {
                                error = Messages.Add.notAdded
                            });
                        }
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
        [Authorize(Policy = "news.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<NewsUpdateDto>(await _newsService.FindByIdIncludeAllAsync(id));
            if (data is null)
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notFound
                });
            }
            ViewBag.categories = _map
                .Map<ICollection<CategoryListDto>>(await _categoryService.GetAllAsync(x => !x.IsDeleted));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "news.update")]
        public async Task<IActionResult> Update(NewsUpdateDto model, List<IFormFile> uploads)
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
                    return RedirectToAction("List", new
                    {
                        error = Messages.Update.notUpdated
                    });
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

        [Authorize(Policy = "news.delete")]
        public async Task Delete(int id)
        {
            var delete = await _newsService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _newsService.UpdateAsync(delete);
        }
        [Authorize(Policy = "news.deleteNewsImage")]
        public async Task<IActionResult> DeleteNewsImage(int id)
        {
            var newsfile = await _newsfileService.FindByIdAsync(id);
            var oldFileImg = await _newsfileService.FindByIdAsync(id);
            _upload.Delete(oldFileImg.Name, "wwwroot/news/");
            await _newsfileService.RemoveAsync(newsfile);
            return RedirectToAction("List");

        }
        [Authorize(Policy = "news.DeleteCategoryFromCategoryNews")]
        public async void DeleteCategoryFromCategoryNews(int newscatId, int categoryId)
        {
            var category = await _categoryNewsService.GetAsync(x => x.NewsId == newscatId && x.CategoryId == categoryId);
            if (category != null)
            {
                await _categoryNewsService.RemoveAsync(category);
            }
        }

        public async Task<JsonResult> GetCategoryList(string searchTerm)
        {
            var CategoryList = _map.Map<List<CategoryListDto>>(await _categoryService
                .GetAllAsync(x => !x.IsDeleted));
            if (searchTerm != null)
            {
                CategoryList = _map.Map<List<CategoryListDto>>(await _categoryService
                .GetAllAsync(x => !x.IsDeleted && x.Name.Contains(searchTerm)));
            }
            var categories = CategoryList.Select(x => new
            {
                text = x.Name,
                id = x.Id,
            });
            return Json(new { items = categories });

        }
    }
}
