using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Extensions;
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
        private readonly ICategoryService _categoryService;

        public NewsController
            (
            IMapper map,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            INewsService newsService,
            ICategoryService categoryService
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _newsService = newsService;
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
            return View(model);
        }

    }
}
