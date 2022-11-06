using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.ReportEmployeeDto
{
    public class ExcellTemplateModel
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int VacDay { get; set; }
        public int TotalDay { get; set; }
        public double TotalHour { get; set; }
        public List<DayItem> DayList { get; set; }
    }
}
