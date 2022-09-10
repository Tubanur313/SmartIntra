using AutoMapper;
using SmartIntranet.DTO.DTOs.PlaceDto;
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
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class PlaceController : BaseIdentityController
    {
        private readonly IPlaceService _placeService;
        public PlaceController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IPlaceService placeService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _placeService = placeService;
        }
        [Authorize(Policy = "place.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = _map.Map<ICollection<PlaceListDto>>(await _placeService.GetAllIncAsync(x => !x.IsDeleted));
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<ICollection<PlaceListDto>>(model).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .Select(x =>
                        new PlaceListDto()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Amount = x.Amount,
                            Currency = GetCurrencyNameByKey(x.Currency),
                            IsDeleted = x.IsDeleted,
                            DeleteByUserId = x.DeleteByUserId
                        }).ToList());
            }
            return View(new List<PlaceListDto>());
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
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var add = _map.Map<Place>(model);
                var current = GetSignInUserId();
                add.CreatedByUserId = current;
                add.CreatedDate = DateTime.Now;
                add.IsDeleted = false;
                if (add.Currency == null)
                    add.Currency = "";

                if (await _placeService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "place.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<PlaceUpdateDto>(await _placeService.FindByIdAsync(id));
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
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
            else
            {
                var data = await _placeService.FindByIdAsync(model.Id);
                var current = GetSignInUserId();
                var update = _map.Map<Place>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                if (update.Currency == null)
                    update.Currency = "";

                await _placeService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "place.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<PlaceListDto>(await _placeService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _placeService.UpdateAsync(_map.Map<Place>(transactionModel));
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
            return GetCurrencies().FirstOrDefault(x => x.Key == key)?.Name;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPlaces()
        {
            IEnumerable<PlaceListDto> data = _map.Map<ICollection<PlaceListDto>>(await _placeService.GetAllIncAsync(x => !x.IsDeleted)).Select(x =>
             new PlaceListDto()
             {
                 Id = x.Id,
                 Name = x.Name
             }).OrderBy(x => x.Name);
            return Ok(data);
        }
    }
}
