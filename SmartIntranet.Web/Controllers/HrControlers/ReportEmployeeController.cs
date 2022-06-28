using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.Entities.Concrete;
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
using SmartIntranet.DTO.DTOs.DepartmentDto;
using System.Linq;
using SmartIntranet.DTO.DTOs;

namespace SmartIntranet.Web.Controllers
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
        public async Task<IActionResult> List()
        {
            IEnumerable<ReportEmployeeListDto> data = _map.Map<ICollection<ReportEmployeeListDto>>(await _reportService.GetAllIncCompAsync(x => !x.IsDeleted));
            return View(data);
        }

        [HttpGet]
        [Authorize(Policy = "reportEmployee.add")]
        public IActionResult Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>( _companyService.GetAllAsync(x => x.IsDeleted  == false).Result);
            return View();
        }

      

        [HttpPost]
        [Authorize(Policy = "reportEmployee.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ReportEmployeeDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var current = GetSignInUserId();
                model.CreatedByUserId = current;
                model.CreatedDate = DateTime.UtcNow;
                model.IsDeleted = false;

                model.FilePath = Guid.NewGuid() +".xlsx";
                ExcellGenerate(model);
              
                await _reportService.AddAsync(_map.Map<ReportEmployee>(model));
                return RedirectToAction("List");
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
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(_companyService.GetAllAsync(x => x.IsDeleted  == false).Result);
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "reportEmployee.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ReportEmployeeDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
            else
            {
                var current = GetSignInUserId();
                
                model.UpdateDate = DateTime.UtcNow;
                model.UpdateByUserId = current;
                DeleteFile("wwwroot/reportDocs/", model.FilePath);
                ExcellGenerate(model);
                await _reportService.UpdateAsync(_map.Map<ReportEmployee>(model));
                return RedirectToAction("List");
            }
        }

        [Authorize(Policy = "reportEmployee.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _map.Map<ReportEmployeeListDto>(await _reportService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _reportService.UpdateAsync(_map.Map<ReportEmployee>(transactionModel));
            return RedirectToAction("List");
        }

        private void ExcellGenerate(ReportEmployeeDto model)
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
                var nonWorkDays = _nonWorkingDayService.GetAllIncCompAsync(x => x.DeleteByUserId == null, year_id).Result;
                var nonWorkDaysToMonth = nonWorkDays.Where(x => x.StartDate.Month <= model.ReportDate.Month || x.EndDate.Month >= model.ReportDate.Month);
                List<ExcellTemplateModel> model_result = new List<ExcellTemplateModel>();
                foreach (var item in users)
                {
                    ExcellTemplateModel mod = new ExcellTemplateModel();
                    mod.DayList = new List<DTO.DTOs.DayItem>();
                    mod.FullName = item.Fullname;
                    mod.Position = item.Position.Name;
                    var graph_id = (int)item.WorkGraphicId;
                    var person_contracts = _personContractService.GetAllIncCompAsync(x => !x.IsDeleted && x.UserId == item.Id && x.Type == PersonalContractConst.WORK_GRAPHIC).Result.ToList().OrderBy(x => x.CommandDate);
                    var this_mn_pc = person_contracts.Where(x => x.CommandDate.Year == model.ReportDate.Year && x.CommandDate.Month == model.ReportDate.Month).OrderBy(x => x.CommandDate);
                    if (person_contracts.Count() > 0 && this_mn_pc.Count() > 0)
                    {

                    }
                    var graph = _workGraphicService.FindByIdAsync(graph_id).Result;
                    var calendar_list = _map.Map<ICollection<WorkCalendarListDto>>( _workCalendarService.GetAllIncCompAsync(x => x.DeleteByUserId == null, year_id, graph.Id).Result);

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
                                        calendar_list = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => x.DeleteByUserId == null, year_id, graph.Id).Result);
                                        break;
                                    }
                                    else
                                    {
                                        graph = _workGraphicService.FindByIdAsync(mn.WorkGraphicId).Result;
                                        calendar_list = _map.Map<ICollection<WorkCalendarListDto>>(_workCalendarService.GetAllIncCompAsync(x => x.DeleteByUserId == null, year_id, graph.Id).Result);
                                    }
                                }
                            }

                            isHoliday = nonWorkDaysToMonth.Any(x => x.StartDate <= day && day <= x.EndDate);
                            if (day.DayOfWeek == DayOfWeek.Sunday)
                            {
                                di.Type = ReportDayType.REST;
                            }
                            if(day.DayOfWeek == DayOfWeek.Saturday && graph.Key == "five_day")
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

                            var vacDay = _vacationContractService.GetAllIncCompAsync(x => x.UserId == item.Id && !x.IsDeleted && x.FromDate <= day && x.ToDate >= day).Result.Count();
                            if (vacDay > 0)
                            {
                                di.Type = ReportDayType.VACATION;
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
                        (dd.Type == ReportDayType.VACATION ? "M" :
                        (dd.Type == ReportDayType.BUSINESS_TRIP ? "E" : ""
                        )))));
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
