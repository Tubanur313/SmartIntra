using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.ReportEmployeeDto
{
    public class WorkTimesheet
    {
        public int ReportId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string ReportCreateMonth { get; set; }
        public DateTime ReportCreateDate { get; set; }
        public DateTime ReportUpdateDate { get; set; }
        public int TotalDay { get; set; }
        public int WorkedTotalDay { get; set; }
        public double TotalHour { get; set; }
        public int VacDay { get; set; }
        public int ExtraHours { get; set; }
        public int Sickdays { get; set; }
        public List<DayItem> DayList { get; set; }
    }
}
