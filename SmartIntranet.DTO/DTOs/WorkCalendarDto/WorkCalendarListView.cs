using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class WorkCalendarListView
    {
        public string Month { get; set; }
        public int TotalDay { get; set; }
        public int TotalHour { get; set; }
        public List<DayType> DayList { get; set; }
    }
}
