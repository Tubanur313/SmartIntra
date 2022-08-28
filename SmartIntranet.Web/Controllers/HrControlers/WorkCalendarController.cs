using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Core.Utilities.Messages;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class WorkCalendarController : BaseIdentityController
    {
        private readonly IWorkCalendarService _workCalendarService;
        private readonly INonWOrkingYearService _nonWOrkingYearService;
        private readonly INonWorkingDayService _nonWorkingDayService;
        private readonly IWorkGraphicService _workGraphicService;
        public WorkCalendarController(UserManager<IntranetUser> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager, IMapper mapper, IWorkCalendarService workCalendarService, INonWOrkingYearService nonWOrkingYearService,
          INonWorkingDayService nonWorkingDayService, IWorkGraphicService workGraphicService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _workCalendarService = workCalendarService;
            _nonWOrkingYearService = nonWOrkingYearService;
            _nonWorkingDayService = nonWorkingDayService;
            _workGraphicService = workGraphicService;
        }

        [Authorize(Policy = "workcalendar.list")]
        public async Task<IActionResult> List(int id, int year_id, string success, string error)
        {
            var model = new List<WorkCalendarListView>();
            ViewBag.id = id;
            ViewBag.year_id = year_id;
            var graph = _workGraphicService.FindByIdAsync(id).Result;
            ViewBag.year =_nonWOrkingYearService.FindByIdAsync(year_id).Result.Year;

            var nonWorkDays = _nonWorkingDayService.GetAllIncCompAsync(x => !x.IsDeleted, year_id).Result;
            var list = _map.Map<ICollection<WorkCalendarListDto>>(await _workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, year_id, id));
            for (int m = 0; m < CalendarConstant.Month.Length; m++)
            {
                var nonWorkDaysToMonth = nonWorkDays.Where(x => x.StartDate.Month <= m + 1 || x.EndDate.Month >= m + 1);
                var item = new WorkCalendarListView();
                item.DayList = new List<DayType>();
                item.Month = CalendarConstant.Month[m];
                for(int i=1; i<=31; i++)
                {
                    var default_count = 0;
                    var color = CalendarConstant.DayColor[0];
                    bool isActive = true;
                    bool isHoliday = false;
                    try
                    {
                        var day = new DateTime(Convert.ToInt32(ViewBag.year), m + 1, i);
                        isHoliday = nonWorkDaysToMonth.Any(x => x.StartDate <= day && day <= x.EndDate);
                        if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                        {
                            color = CalendarConstant.DayColor[2];
                        }

                      
                        switch (day.DayOfWeek)
                        {
                            case DayOfWeek.Monday: default_count = graph.Monday; break;
                            case DayOfWeek.Tuesday: default_count = graph.Tuesday; break;
                            case DayOfWeek.Wednesday: default_count = graph.Wednesday; break;
                            case DayOfWeek.Thursday: default_count = graph.Thursday; break;
                            case DayOfWeek.Friday: default_count = graph.Friday; break;
                            case DayOfWeek.Saturday: default_count = graph.Saturday; break;
                            case DayOfWeek.Sunday: default_count = graph.Sunday; break;
                        }

                        if (isHoliday)
                        {
                            color = CalendarConstant.DayColor[1];
                            default_count = 0;
                        }

                    }
                    catch
                    {
                        isActive = false;
                    }

                    var el = list.FirstOrDefault(x => x.Month == item.Month && x.Day == i);
                    if (el != null)
                    {
                        item.DayList.Add(new DayType() { Id = el.Id, Number = el.Number, Day = i , Type = color, IsActive = isActive });
                        item.TotalHour += el.Number;
                        item.TotalDay++;
                    }
                    else
                    {
                        if (default_count != 0)
                        {
                            item.TotalHour += default_count;
                            item.TotalDay++;
                        }
                        item.DayList.Add(new DayType() { Id = 0, Number = default_count, Day = i , Type = color, IsActive = isActive });
                    }
                  
                }
                model.Add(item);
            }
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                return View(_map.Map<ICollection<WorkCalendarListView>>(model).ToList());
            }
            return View(new List<WorkCalendarListView>());
        }

        [HttpGet]
        [Authorize(Policy = "workcalendar.add")]
        public async Task<IActionResult> Add(int number, int day, string month, int workGraphicId, int nonWorkingYearId)
        {
           return View();
        }

        [HttpPost]
        [Authorize(Policy = "workcalendar.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(WorkCalendarAddDto model)
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
                var add = _map.Map<WorkCalendar>(model);
                add.CreatedByUserId = current;
                add.IsDeleted = false;
                add.CreatedDate = DateTime.Now;
                if (await _workCalendarService.AddReturnEntityAsync(add) is null)
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Add.notAdded,
                        id = model.WorkGraphicId,
                        year_id = model.NonWorkingYearId
                    });
                }
                return RedirectToAction("List", new
                {
                    success = Messages.Add.Added,
                    id = model.WorkGraphicId,
                    year_id = model.NonWorkingYearId
                });
            }
        }

        [HttpGet]
        [Authorize(Policy = "workcalendar.update")]
        public async Task<IActionResult> Update(int id, int number, int day, string month, int workGraphicId, int nonWorkingYearId)
        {
            var listModel = _map.Map<WorkCalendarUpdateDto>(await _workCalendarService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "workcalendar.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(WorkCalendarUpdateDto model)
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
                //if (model.Number == 0)
                //{
                //    return RedirectToAction("Delete", new { id = model.Id });
                //}
                var data = await _workCalendarService.FindByIdAsync(model.Id);
                var current = GetSignInUserId();
                var update = _map.Map<WorkCalendar>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                await _workCalendarService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated,
                    id = model.WorkGraphicId,
                    year_id = model.NonWorkingYearId
                });
            }
        }

        [Authorize(Policy = "workcalendar.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<WorkCalendarListDto>(await _workCalendarService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _workCalendarService.UpdateAsync(_map.Map<WorkCalendar>(transactionModel));
        }
    }
}
