using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.NonWorkingDayDto;
using SmartIntranet.DTO.DTOs.PlaceDto;
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

namespace SmartIntranet.Web.Controllers
{
    public class PlaceController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        private readonly IPlaceService _placeService;
        public PlaceController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IPlaceService placeService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _mapper = mapper;
            _placeService = placeService;
        }
        [Authorize(Policy = "place.list")]
        public async Task<IActionResult> List()
        {
            IEnumerable<PlaceListDto> data = _mapper.Map<ICollection<PlaceListDto>>(await _placeService.GetAllIncAsync(x => !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList().Select(x =>
            new PlaceListDto()
            {
                Id = x.Id,
                Name = x.Name,
                Amount = x.Amount,
                Currency = GetCurrencyNameByKey(x.Currency),
                IsDeleted = x.IsDeleted,
                DeleteByUserId = x.DeleteByUserId
            });
            return View(data);
        }

        [HttpGet]
        [Authorize(Policy = "place.add")]
        public IActionResult Add()
        {
            ViewBag.Currencies = GetCurrencies();
            return View();
        }



        [HttpPost]
        [Authorize(Policy = "place.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PlaceAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var current = GetSignInUserId();
                model.CreatedByUserId = current;
                model.CreatedDate = DateTime.UtcNow.AddHours(4);
                model.IsDeleted = false;
                await _placeService.AddAsync(_mapper.Map<Place>(model));
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        [Authorize(Policy = "place.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _mapper.Map<PlaceUpdateDto>(await _placeService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            ViewBag.Currencies = GetCurrencies();
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "place.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PlaceUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
            else
            {
                var current = GetSignInUserId();

                model.UpdateDate = DateTime.UtcNow.AddHours(4);
                model.UpdateByUserId = current;

                await _placeService.UpdateAsync(_mapper.Map<Place>(model));
                return RedirectToAction("List");
            }
        }

        [Authorize(Policy = "place.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _mapper.Map<PlaceListDto>(await _placeService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _placeService.UpdateAsync(_mapper.Map<Place>(transactionModel));
            return Ok();
        }

        public List<Currency> GetCurrencies()
        {
            List<Currency> currencies = new List<Currency>();
            currencies.Add(new Currency { Key = "AZN", Name = "Manat" });
            currencies.Add(new Currency { Key = "USD", Name = "Dollar" });
            currencies.Add(new Currency { Key = "EUR", Name = "Avro" });
            currencies.Add(new Currency { Key = "JPY", Name = "Yapon iyeni" });
            currencies.Add(new Currency { Key = "GBP", Name = "Funt sterlinq" });
            return currencies;
        }

        public string GetCurrencyNameByKey(string key)
        {
            return GetCurrencies().FirstOrDefault(x => x.Key == key).Name;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPlaces()
        {
            IEnumerable<PlaceListDto> data = _mapper.Map<ICollection<PlaceListDto>>(await _placeService.GetAllIncAsync(x => x.DeleteByUserId == null)).Select(x =>
             new PlaceListDto()
             {
                 Id = x.Id,
                 Name = x.Name
             }).OrderBy(x => x.Name);
            return Ok(data);
        }
    }
}
