using AutoMapper;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs.ReportEmployeeDto;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Linq;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.DTO.DTOs.WorkCalendarDto;
using SmartIntranet.Entities.Concrete.IntraHr;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient.DataClassification;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class ReportEmployeeController : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IReportEmployeeService _reportService;
        private readonly IWorkGraphicService _workGraphicService;
        private readonly IWorkCalendarService _workCalendarService;
        private readonly ICompanyService _companyService;
        private readonly IVacationContractService _vacationContractService;
        private readonly IBusinessTripService _businessTripService;
        private readonly INonWorkingDayService _nonWorkingDayService;
        private readonly ITerminationContractService _terminationContractService;
        private readonly IPersonalContractService _personContractService;
        private readonly INonWOrkingYearService _nonWorkingYearService;
        public ReportEmployeeController(UserManager<IntranetUser> userManager, ITerminationContractService terminationContractService, IWorkGraphicService workGraphicService, IWorkCalendarService workCalendarService, ICompanyService companyService, IPersonalContractService personContractService, IVacationContractService vacationContractService, IHttpContextAccessor httpContextAccessor, IAppUserService appUserService, SignInManager<IntranetUser> signInManager, IBusinessTripService businessTripService, INonWorkingDayService nonWorkingDayService, IMapper mapper, INonWOrkingYearService nonWorkingYearService, IReportEmployeeService reportService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _reportService = reportService;
            _workGraphicService = workGraphicService;
            _workCalendarService = workCalendarService;
            _nonWorkingDayService = nonWorkingDayService;
            _vacationContractService = vacationContractService;
            _terminationContractService = terminationContractService;
            _nonWorkingYearService = nonWorkingYearService;
            _personContractService = personContractService;
            _businessTripService = businessTripService;
            _companyService = companyService;
            _appUserService = appUserService;
        }
        [Authorize(Policy = "reportEmployee.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = await _reportService.GetAllIncCompAsync(x => !x.IsDeleted);
            var modelDto = _map.Map<List<ReportEmployeeListDto>>(await _reportService.GetAllIncCompAsync(x => !x.IsDeleted));
            if (model.Any())
            {
                TempData["success"] = success;
                TempData["error"] = error;
                for (int i = 0; i < model.Count; i++)
                {
                    if (model[i].GeneratedReport == null)
                    {
                        modelDto[i].IsGenerated = true;
                    }
                }
                return View(_map.Map<ICollection<ReportEmployeeListDto>>(modelDto).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
            }
            return View(new List<ReportEmployeeListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "reportEmployee.add")]
        public IActionResult Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_companyService.GetAllAsync(x => x.IsDeleted == false).Result);
            return View();
        }



        [HttpPost]
        [Authorize(Policy = "reportEmployee.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ReportEmployeeDto model)
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
                var add = _map.Map<ReportEmployee>(model);
                add.CreatedByUserId = current;
                add.CreatedDate = DateTime.Now;
                add.IsDeleted = false;

                add.FilePath = Guid.NewGuid() + ".xlsx";
                //ExcellGenerate(add);

                if (await _reportService.AddReturnEntityAsync(add) is null)
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
        [Authorize(Policy = "reportEmployee.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<ReportEmployeeDto>(await _reportService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_companyService.GetAllAsync(x => x.IsDeleted == false).Result);
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "reportEmployee.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ReportEmployeeDto model)
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
                var data = await _reportService.FindByIdAsync(model.Id);
                var update = _map.Map<ReportEmployee>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;
                update.FilePath = data.FilePath;
                DeleteFile("wwwroot/reportDocs/", update.FilePath);
                ExcellGenerate(update);

                await _reportService.UpdateReturnEntityAsync(update);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
        }

        [Authorize(Policy = "reportEmployee.workTimesheet")]
        public async Task<IActionResult> WorkTimesheet(ReportEmployeeDto model)
        {
            var countDayInMonth = DateTime.DaysInMonth(model.ReportDate.Year, model.ReportDate.Month);
            var firstReportDay = new DateTime(model.ReportDate.Year, model.ReportDate.Month, 1);
            var lastReportDay = new DateTime(model.ReportDate.Year, model.ReportDate.Month, countDayInMonth);
            var userTerminated = await _terminationContractService.GetAllAsync();
            var users = await _appUserService.GetAllIncludeAsync(x => x.CompanyId == model.CompanyId
            && x.StartWorkDate <= lastReportDay
            && !x.IsDeleted && x.Email != "tahiroglumahir@gmail.com");

            var yearId = _nonWorkingYearService.GetAllIncCompAsync(x => x.Year == model.ReportDate.Year.ToString()).Result[0].Id;
            var nonWorkDays = _nonWorkingDayService.GetAllIncCompAsync(x => !x.IsDeleted, yearId).Result;
            var nonWorkDaysToMonth = nonWorkDays.Where(x => x.StartDate.Month <= model.ReportDate.Month || x.EndDate.Month >= model.ReportDate.Month);
            var modelResult = new List<WorkTimesheet>();
            foreach (var item in users
                .OrderByDescending(x => x.Company.Id).ToList())
            {
                if (userTerminated.Any(x => x.UserId == item.Id && x.TerminationDate <= firstReportDay))
                {
                    goto Label1;
                }
                var mod = new WorkTimesheet
                {
                    ReportId = model.Id,
                    DayList = new List<DayItem>(),
                    FullName = item.Fullname,
                    Position = item.PositionId > 0 ? item.Position.Name : "",
                    ReportCreateDate = model.ReportDate,
                    ReportCreateMonth = "01." + model.ReportDate.ToString("MM.yyyy")
                                                  + " -" + DateTime.DaysInMonth(model.ReportDate.Year, model.ReportDate.Month)
                                                  + "." + model.ReportDate.ToString("MM.yyyy"),
                    CompanyName = item.CompanyId > 0 ? item.Company.Name : ""
                };
                var graphId = (int)item.WorkGraphicId;
                var personContracts = _personContractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == item.Id && x.Type == PersonalContractConst.WORK_GRAPHIC).Result.ToList().OrderBy(x => x.CommandDate);
                var this_mn_pc = personContracts.Where(x => x.CommandDate.Year == model.ReportDate.Year && x.CommandDate.Month == model.ReportDate.Month).OrderBy(x => x.CommandDate);
                if (personContracts.Any() && this_mn_pc.Any())
                {
                }

                WorkGraphic graph = _workGraphicService.FindByIdAsync(graphId).Result;
                var calendarList = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, yearId, graph.Id).Result);


                int countSundays = 0;
                int countHolySundays = 0;
                for (int i = 1; i < countDayInMonth; i++)
                {
                    DateTime d = new DateTime(model.ReportDate.Year, model.ReportDate.Month, i);
                    if (d.DayOfWeek == DayOfWeek.Sunday)
                    {
                        countSundays++;

                    }
                    foreach (var nw in nonWorkDays)
                    {
                        if (d >= nw.StartDate && d <= nw.EndDate && d.DayOfWeek != DayOfWeek.Sunday)
                        {
                            countHolySundays++;
                        }
                    }
                }
                int countSaturdays = 0;
                int countHolySaturdays = 0;
                for (int i = 0; i < countDayInMonth; i++)
                {
                    DateTime d = new DateTime(model.ReportDate.Year, model.ReportDate.Month, i + 1);
                    if (d.DayOfWeek == DayOfWeek.Saturday)
                    {
                        countSaturdays++;

                    }
                    foreach (var nw in nonWorkDays)
                    {
                        if (d >= nw.StartDate && d <= nw.EndDate && d.DayOfWeek != DayOfWeek.Saturday)
                        {
                            countHolySaturdays++;
                        }
                    }
                }
                if (graph.Sunday == 0 && graph.Saturday == 0)
                {
                    mod.TotalDay = Math.Abs(countDayInMonth - (countSundays + countSaturdays + countHolySaturdays));
                }
                else
                {
                    mod.TotalDay = Math.Abs(countDayInMonth - (countSundays + countHolySaturdays));
                }
                for (var i = 1; i <= 31; i++)
                {
                    DateTime exactday = new DateTime(model.ReportDate.Year, model.ReportDate.Month, i);
                    var defaultCount = 0;
                    var isActive = true;
                    var isHoliday = false;
                    int holidayCount = 0;
                    var di = new DayItem();
                    try
                    {
                        di.Type = ReportDayType.NORMAL;
                        var day = new DateTime(model.ReportDate.Year, model.ReportDate.Month, i);
                        if (personContracts.Any() && this_mn_pc.Any())
                        {
                            foreach (var mn in this_mn_pc)
                            {
                                if (mn.CommandDate > day)
                                {
                                    graph = _workGraphicService.FindByIdAsync(mn.LastWorkGraphicId).Result;
                                    calendarList = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, yearId, graph.Id).Result);
                                    break;
                                }
                                else
                                {
                                    graph = _workGraphicService.FindByIdAsync(mn.WorkGraphicId).Result;
                                    calendarList = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, yearId, graph.Id).Result);
                                }
                            }
                        }

                        isHoliday = nonWorkDaysToMonth.Any(x => x.StartDate <= day && day <= x.EndDate);
                        var hasAnyHolidayToCurrentday = nonWorkDaysToMonth.Any(x => x.StartDate <= day);
                        switch (day.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                            case DayOfWeek.Saturday when graph.Key == "five_day":
                                di.Type = ReportDayType.REST;
                                break;
                        }

                        defaultCount = day.DayOfWeek switch
                        {
                            DayOfWeek.Monday => graph.Monday,
                            DayOfWeek.Tuesday => graph.Tuesday,
                            DayOfWeek.Wednesday => graph.Wednesday,
                            DayOfWeek.Thursday => graph.Thursday,
                            DayOfWeek.Friday => graph.Friday,
                            DayOfWeek.Saturday => graph.Saturday,
                            DayOfWeek.Sunday => graph.Sunday,
                            _ => defaultCount
                        };
                        if (hasAnyHolidayToCurrentday)
                        {
                            holidayCount++;
                        }
                        if (isHoliday)
                        {
                            di.Type = ReportDayType.HOLIDAY;
                            defaultCount = 0;
                        }

                        if (item.StartWorkDate > day)
                        {
                            di.Type = ReportDayType.NON_DAY;
                            defaultCount = 0;
                        }

                        var vac = _vacationContractService.GetAllIncCompAsync(x => x.UserId == item.Id && !x.IsDeleted && x.FromDate <= day && x.ToDate.AddDays(holidayCount) >= day).Result;
                        var vacDay = vac.Count();
                        if (!isHoliday && vacDay > 0)
                        {
                            var type_vac = vac.FirstOrDefault().VacationType.Key;

                            di.Type = type_vac == VacationTypeConst.LABOR ? ReportDayType.MAIN_VACATION :
                                (type_vac == VacationTypeConst.WITHOUT_PRICE ? ReportDayType.WITHOUT_PRICE_VACATION :
                                 (type_vac == VacationTypeConst.PREGNANCY ? ReportDayType.MOTHER_VACATION :
                                (type_vac == VacationTypeConst.SOCIAL ? ReportDayType.SOCIAL_VACATION :
                                 (type_vac == VacationTypeConst.EDU ? ReportDayType.EDU_VACATION : ""))));
                            defaultCount = 0;
                            mod.VacDay++;
                        }

                        var terDay = _terminationContractService.GetAllIncCompAsync(x => x.UserId == item.Id && !x.IsDeleted && x.TerminationDate <= day).Result.Count();
                        if (terDay > 0)
                        {
                            di.Type = ReportDayType.NON_DAY;
                            defaultCount = 0;
                        }

                        if (_businessTripService.GetAllAsync(x => !x.IsDeleted).Result.Select(bt => bt.BusinessTripUsers.Where(x => !x.IsDeleted && x.UserId == item.Id && x.StartDate <= day && x.EndDate >= day).Count()).Any(business_trip_for_user => business_trip_for_user > 0))
                        {
                            di.Type = ReportDayType.BUSINESS_TRIP;
                            defaultCount = 0;
                        }

                    }
                    catch
                    {
                        isActive = false;
                    }


                    var editedCalendarList = calendarList.FirstOrDefault(x => x.Month == CalendarConstant.Month[model.ReportDate.Month - 1] && x.Day == i);
                    if (editedCalendarList != null)
                    {
                        if (editedCalendarList.Number > 0)
                        {

                            if (exactday.DayOfWeek == DayOfWeek.Sunday || exactday.DayOfWeek == DayOfWeek.Saturday)
                            {
                                if (di.Type == ReportDayType.REST)
                                {
                                    mod.DayList.Add(new DayItem() { Number = editedCalendarList.Number, Day = i, Type = ReportDayType.NORMAL });
                                    mod.TotalHour += editedCalendarList.Number;
                                }
                            }
                            else
                            {
                                mod.DayList.Add(new DayItem() { Number = editedCalendarList.Number, Day = i, Type = di.Type });
                                mod.TotalHour += editedCalendarList.Number;
                            }
                        }
                        else
                        {

                            if (di.Type == ReportDayType.NORMAL)
                            {
                                mod.DayList.Add(new DayItem() { Number = editedCalendarList.Number, Day = i, Type = ReportDayType.REST });
                                mod.TotalHour += editedCalendarList.Number;
                            }
                            else
                            {
                                mod.DayList.Add(new DayItem { Number = defaultCount, Day = i, Type = di.Type });
                            }
                        }
                    }
                    else
                    {
                        if (defaultCount != 0)
                        {
                            mod.TotalHour += defaultCount;
                            //mod.TotalDay++;
                        }

                        mod.DayList.Add(new DayItem { Number = defaultCount, Day = i, Type = di.Type });
                    }


                }
                modelResult.Add(mod);
            Label1:;
            }

            return View(modelResult);
        }


        [HttpGet]
        [Authorize(Policy = "reportEmployee.getsavedreport")]
        public async Task<IActionResult> GetSavedReport(int id)
        {
            var model = await _reportService.FindByIdAsync(id);
            if (model == null || !(model.CompanyId > 0) || model.GeneratedReport == null)
            {
                return View(new List<WorkTimesheet>());
            }
            var comp = await _companyService.FindByIdAsync(model.CompanyId);

            var reports = JsonConvert.DeserializeObject<List<dynamic>>(model.GeneratedReport);
            var listReport = new List<WorkTimesheet>();
            for (var i = 0; i < reports.Count; i++)
            {
                var days = new List<DayItem>();
                for (var j = 3; j < reports[i].Count - 6; j++)
                {
                    var day = new DayItem
                    {
                        Type = reports[i][j]
                    };
                    days.Add(day);
                }
                var report = new WorkTimesheet
                {
                    ReportCreateMonth = "01." + model.ReportDate.ToString("MM.yyyy")
                                              + " -" + DateTime.DaysInMonth(model.ReportDate.Year, model.ReportDate.Month)
                                              + "." + model.ReportDate.ToString("MM.yyyy"),
                    ReportUpdateDate = model.UpdateDate.Value,
                    ReportCreateDate = model.ReportDate,
                    CompanyName = comp.Name,
                    ReportId = id,
                    FullName = reports[i][1],
                    Position = reports[i][2],
                    TotalDay = reports[i][34],
                    WorkedTotalDay = reports[i][35],
                    TotalHour = reports[i][36],
                    VacDay = reports[i][37],
                    ExtraHours = reports[i][38],
                    Sickdays = reports[i][39],
                    DayList = days
                };
                listReport.Add(report);

            }

            return View(listReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateReport(string report, int reportId, string updatedate)
        {
            var reports = await _reportService.FindByIdAsync(reportId);
            reports.GeneratedReport = report;
            reports.UpdateDate = updatedate != null ? DateTime.Parse(updatedate) : DateTime.Now;
            reports.UpdateByUserId = GetSignInUserId();
            var result = await _reportService.UpdateReturnEntityAsync(reports);
            return result is null ? (IActionResult)BadRequest(Messages.Error.notFound) : Ok(Messages.Update.updated);
        }

        [Authorize(Policy = "reportEmployee.delete")]
        public async Task Delete(int id)
        {
            var transactionModel = _map.Map<ReportEmployeeListDto>(await _reportService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.Now;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _reportService.UpdateAsync(_map.Map<ReportEmployee>(transactionModel));
        }

        private void ExcellGenerate(ReportEmployee model)
        {
            var users = _appUserService.GetAllIncludeAsync(x => x.CompanyId == model.CompanyId && !x.IsDeleted).Result;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/reportDocs/" + model.FilePath);
            FileInfo file = new FileInfo(path);
            var memory = new MemoryStream();

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var workBook = new XSSFWorkbook();
                ISheet sheet = workBook.CreateSheet(model.ReportDate.ToString("MM.yyyy"));

                //var cra_1 = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 2);
                //sheet.AddMergedRegion(cra_1);

                //var cra_2 = new NPOI.SS.Util.CellRangeAddress(1, 10, 0, 0);
                //sheet.AddMergedRegion(cra_2);

                //var cra_3 = new NPOI.SS.Util.CellRangeAddress(1, 1, 2, 40);
                //sheet.AddMergedRegion(cra_3);

                //var cra_4 = new NPOI.SS.Util.CellRangeAddress(3, 6, 1, 1);
                //sheet.AddMergedRegion(cra_4);

                var headers = sheet.CreateRow(11);
                var font = workBook.CreateFont();
                font.FontHeightInPoints = 11;
                font.FontName = "Times New Roman";
                font.Boldweight = (short)FontBoldWeight.Bold;

                var font_thin = workBook.CreateFont();
                font_thin.FontHeightInPoints = 11;
                font_thin.FontName = "Times New Roman";
                font_thin.Boldweight = (short)FontBoldWeight.Normal;

                ICellStyle style = workBook.CreateCellStyle();
                style.SetFont(font_thin);
                style.Alignment = HorizontalAlignment.Left;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;

                ICellStyle style_bold = workBook.CreateCellStyle();
                style_bold.SetFont(font);
                style_bold.Alignment = HorizontalAlignment.Left;
                style_bold.VerticalAlignment = VerticalAlignment.Center;
                style_bold.BorderBottom = BorderStyle.Thin;
                style_bold.BorderLeft = BorderStyle.Thin;
                style_bold.BorderTop = BorderStyle.Thin;
                style_bold.BorderRight = BorderStyle.Thin;

                ICellStyle style_simple = workBook.CreateCellStyle();
                style_simple.SetFont(font);
                style_simple.Alignment = HorizontalAlignment.Left;
                style_simple.VerticalAlignment = VerticalAlignment.Center;


                ICellStyle style_none = workBook.CreateCellStyle();
                style_none.SetFont(font);
                style_none.BorderBottom = BorderStyle.None;
                style_none.Alignment = HorizontalAlignment.Left;
                style_none.VerticalAlignment = VerticalAlignment.Center;

                ICellStyle style_line = workBook.CreateCellStyle();
                style_line.SetFont(font);
                style_line.Alignment = HorizontalAlignment.Left;
                style_line.VerticalAlignment = VerticalAlignment.Center;
                style_line.BorderBottom = BorderStyle.Medium;

                ICellStyle style_right = workBook.CreateCellStyle();
                style_right.SetFont(font);
                style_right.Alignment = HorizontalAlignment.Right;
                style_right.VerticalAlignment = VerticalAlignment.Center;


                var font_normal = workBook.CreateFont();
                font_normal.FontHeightInPoints = 11;
                font_normal.FontName = "Times New Roman";
                font_normal.Boldweight = (short)FontBoldWeight.Normal;

                ICellStyle style_normal = workBook.CreateCellStyle();
                style_normal.SetFont(font_normal);
                style_normal.Alignment = HorizontalAlignment.Left;
                style_normal.VerticalAlignment = VerticalAlignment.Center;

                // ROW-0
                var row_1 = sheet.CreateRow(0);
                for (int i = 1; i <= 31; i++)
                {
                    var item = row_1.CreateCell(i + 2, CellType.Numeric);
                    item.CellStyle = style_bold;
                    item.SetCellValue(i);
                }
                // ROW-1
                var row_2 = sheet.CreateRow(1);
                var company_name = row_2.CreateCell(1, CellType.String);
                company_name.CellStyle = style_line;
                company_name.SetCellValue(users[0].Company.Name);

                // ROW-3
                var row_3 = sheet.CreateRow(2);
                var date_report = row_3.CreateCell(1, CellType.String);
                date_report.CellStyle = style_right;
                date_report.SetCellValue(model.ReportDate.ToString("MM.yyyy"));

                // ROW-4
                var row_4 = sheet.CreateRow(4);
                var accept = row_4.CreateCell(13, CellType.String);
                accept.CellStyle = style_simple;
                accept.SetCellValue("TƏSDİQ EDİRƏM:");

                // ROW-7
                var row_7 = sheet.CreateRow(7);
                var date_label = row_7.CreateCell(1, CellType.String);
                date_label.CellStyle = style_line;
                date_label.SetCellValue("İş vaxtının uçotu tabeli");

                for (int i = 2; i < 36; i++)
                {
                    var border_bottom_7 = row_7.CreateCell(i, CellType.String);
                    border_bottom_7.CellStyle = style_line;
                    border_bottom_7.SetCellValue("");
                }

                // ROW-9
                var row_9 = sheet.CreateRow(9);
                var date_range = row_9.CreateCell(1, CellType.String);
                date_range.CellStyle = style_simple;
                var dat_rep = model.ReportDate.ToString("MM.yyyy");
                date_range.SetCellValue("01." + dat_rep + " -" + DateTime.DaysInMonth(model.ReportDate.Year, model.ReportDate.Month) + "." + dat_rep);


                // ROW-4 end
                var director_cell = row_4.CreateCell(25, CellType.String);
                director_cell.CellStyle = style_line;
                director_cell.SetCellValue(users[0].Company.Leader.Fullname);

                // ROW-5 end
                var row_5_end = sheet.CreateRow(5);
                var director_cell_below = row_5_end.CreateCell(25, CellType.String);
                director_cell_below.CellStyle = style_simple;
                director_cell_below.SetCellValue("Direktor");


                // HEADERS
                var idCell = headers.CreateCell(0);
                idCell.SetCellValue("S. N-si");
                idCell.CellStyle = style_bold;
                var structureCell = headers.CreateCell(1);
                structureCell.SetCellValue("Soyadı, adı, atasının adı");
                structureCell.CellStyle = style_bold;
                var orderIdCell = headers.CreateCell(2);
                orderIdCell.SetCellValue("Vəzifəsi");
                orderIdCell.CellStyle = style_bold;

                // ROW-11
                for (int i = 1; i <= 31; i++)
                {
                    var item = headers.CreateCell(i + 2, CellType.Numeric);
                    item.CellStyle = style_bold;
                    item.SetCellValue(i);
                }

                var day_count = headers.CreateCell(34);
                day_count.SetCellValue("İş günlərinin sayı");
                day_count.CellStyle = style_bold;
                var hour_count = headers.CreateCell(35);
                hour_count.SetCellValue("İş saatlarının sayı");
                hour_count.CellStyle = style_bold;
                var vac_count = headers.CreateCell(36);
                vac_count.SetCellValue("Məzuniyyət günlərinin sayı");
                vac_count.CellStyle = style_bold;

                // DB get data
                var year_id = _nonWorkingYearService.GetAllIncCompAsync(x => x.Year == model.ReportDate.Year.ToString()).Result[0].Id;
                var nonWorkDays = _nonWorkingDayService.GetAllIncCompAsync(x => !x.IsDeleted, year_id).Result;
                var nonWorkDaysToMonth = nonWorkDays.Where(x => x.StartDate.Month <= model.ReportDate.Month || x.EndDate.Month >= model.ReportDate.Month);
                List<ExcellTemplateModel> model_result = new List<ExcellTemplateModel>();
                foreach (var item in users)
                {
                    ExcellTemplateModel mod = new ExcellTemplateModel();
                    mod.DayList = new List<DayItem>();
                    mod.FullName = item.Fullname;
                    mod.Position = item.Position.Name;
                    var graph_id = (int)item.WorkGraphicId;
                    var person_contracts = _personContractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == item.Id && x.Type == PersonalContractConst.WORK_GRAPHIC).Result.ToList().OrderBy(x => x.CommandDate);
                    var this_mn_pc = person_contracts.Where(x => x.CommandDate.Year == model.ReportDate.Year && x.CommandDate.Month == model.ReportDate.Month).OrderBy(x => x.CommandDate);
                    if (person_contracts.Count() > 0 && this_mn_pc.Count() > 0)
                    {

                    }
                    var graph = _workGraphicService.FindByIdAsync(graph_id).Result;
                    var calendar_list = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, year_id, graph.Id).Result);

                    for (int i = 1; i <= 31; i++)
                    {
                        var default_count = 0;
                        bool isActive = true;
                        bool isHoliday = false;
                        DayItem di = new DayItem();
                        try
                        {


                            di.Type = ReportDayType.NORMAL;
                            var day = new DateTime(model.ReportDate.Year, model.ReportDate.Month, i);

                            if (person_contracts.Count() > 0 && this_mn_pc.Count() > 0)
                            {
                                foreach (var mn in this_mn_pc)
                                {
                                    if (mn.CommandDate > day)
                                    {
                                        graph = _workGraphicService.FindByIdAsync(mn.LastWorkGraphicId).Result;
                                        calendar_list = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, year_id, graph.Id).Result);
                                        break;
                                    }
                                    else
                                    {
                                        graph = _workGraphicService.FindByIdAsync(mn.WorkGraphicId).Result;
                                        calendar_list = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => !x.IsDeleted, year_id, graph.Id).Result);
                                    }
                                }
                            }

                            isHoliday = nonWorkDaysToMonth.Any(x => x.StartDate <= day && day <= x.EndDate);
                            if (day.DayOfWeek == DayOfWeek.Sunday)
                            {
                                di.Type = ReportDayType.REST;
                            }
                            if (day.DayOfWeek == DayOfWeek.Saturday && graph.Key == "five_day")
                            {
                                di.Type = ReportDayType.REST;
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
                                di.Type = ReportDayType.HOLIDAY;
                                default_count = 0;
                            }

                            if (item.StartWorkDate > day)
                            {
                                di.Type = ReportDayType.NON_DAY;
                                default_count = 0;
                            }

                            var vac = _vacationContractService.GetAllIncCompAsync(x => x.UserId == item.Id && !x.IsDeleted && x.FromDate <= day && x.NextWorkDate > day).Result;
                            var vacDay = vac.Count();
                            if (!isHoliday && vacDay > 0)
                            {
                                var type_vac = vac.FirstOrDefault().VacationType.Key;

                                di.Type = type_vac == VacationTypeConst.LABOR ? ReportDayType.MAIN_VACATION :
                                    (type_vac == VacationTypeConst.WITHOUT_PRICE ? ReportDayType.WITHOUT_PRICE_VACATION :
                                     (type_vac == VacationTypeConst.PREGNANCY ? ReportDayType.MOTHER_VACATION :
                                    (type_vac == VacationTypeConst.SOCIAL ? ReportDayType.SOCIAL_VACATION :
                                     (type_vac == VacationTypeConst.EDU ? ReportDayType.EDU_VACATION : ""))));
                                default_count = 0;
                                mod.VacDay++;
                            }

                            var terDay = _terminationContractService.GetAllIncCompAsync(x => x.UserId == item.Id && !x.IsDeleted && x.TerminationDate <= day).Result.Count();
                            if (terDay > 0)
                            {
                                di.Type = ReportDayType.NON_DAY;
                                default_count = 0;
                            }

                            foreach (var bt in _businessTripService.GetAllAsync(x => !x.IsDeleted).Result)
                            {
                                var business_trip_for_user = bt.BusinessTripUsers.Where(x => !x.IsDeleted && x.UserId == item.Id && x.StartDate <= day && x.EndDate >= day).Count();
                                if (business_trip_for_user > 0)
                                {
                                    di.Type = ReportDayType.BUSINESS_TRIP;
                                    default_count = 0;
                                    break;
                                }

                            }


                        }
                        catch
                        {
                            isActive = false;
                        }

                        var el = calendar_list.FirstOrDefault(x => x.Month == model.ReportDate.Month.ToString() && x.Day == i);
                        if (el != null)
                        {
                            mod.DayList.Add(new DayItem() { Number = el.Number, Day = i, Type = di.Type });
                            mod.TotalHour += el.Number;
                            mod.TotalDay++;
                        }
                        else
                        {
                            if (default_count != 0)
                            {
                                mod.TotalHour += default_count;
                                mod.TotalDay++;
                            }
                            mod.DayList.Add(new DayItem() { Number = default_count, Day = i, Type = di.Type });
                        }

                    }

                    model_result.Add(mod);
                }


                //
                int counter = 12;
                int emp_id = 1;
                foreach (var item in model_result)
                {
                    var row = sheet.CreateRow(counter);
                    var idColumn = row.CreateCell(0, CellType.Numeric);
                    idColumn.CellStyle = style;
                    idColumn.SetCellValue(emp_id);
                    var fullName = row.CreateCell(1, CellType.String);
                    fullName.CellStyle = style;
                    fullName.SetCellValue(item.FullName);
                    var structureColumn = row.CreateCell(2, CellType.String);
                    structureColumn.CellStyle = style;
                    structureColumn.SetCellValue(item.Position);
                    foreach (var dd in item.DayList)
                    {
                        var day_of_month = row.CreateCell(2 + dd.Day, CellType.String);
                        day_of_month.CellStyle = style;
                        day_of_month.SetCellValue(dd.Type == ReportDayType.NORMAL ? dd.Number.ToString() :
                        (dd.Type == ReportDayType.REST ? "İ" :
                        (dd.Type == ReportDayType.HOLIDAY ? "B" :
                        (dd.Type == ReportDayType.MAIN_VACATION ? "M" :
                        (dd.Type == ReportDayType.WITHOUT_PRICE_VACATION ? "Ö/M" :
                        (dd.Type == ReportDayType.MOTHER_VACATION ? "A/M" :
                        (dd.Type == ReportDayType.EDU_VACATION ? "T/M" :
                        (dd.Type == ReportDayType.SOCIAL_VACATION ? "S/M" :
                        (dd.Type == ReportDayType.BUSINESS_TRIP ? "E" : ""
                        )))))))));
                    }

                    var day_cell_34 = row.CreateCell(34, CellType.Numeric);
                    day_cell_34.CellStyle = style;
                    day_cell_34.SetCellValue(item.TotalDay);
                    var day_cell_35 = row.CreateCell(35, CellType.String);
                    day_cell_35.CellStyle = style;
                    day_cell_35.SetCellValue(item.TotalHour);
                    var day_cell_36 = row.CreateCell(36, CellType.String);
                    day_cell_36.CellStyle = style;
                    day_cell_36.SetCellValue(item.VacDay);

                    counter++;
                    emp_id++;
                }
                sheet.AutoSizeColumn(1);
                sheet.AutoSizeColumn(2);
                sheet.AutoSizeColumn(34);
                sheet.AutoSizeColumn(35);
                sheet.AutoSizeColumn(36);

                workBook.Write(fs);
            }
        }
    }
}
