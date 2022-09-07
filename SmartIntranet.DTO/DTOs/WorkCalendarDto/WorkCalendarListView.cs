using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.WorkCalendarDto
{
    public class WorkCalendarListView
    {
        public string Month { get; set; }
        public int TotalDay { get; set; }
        public int TotalHour { get; set; }
        public List<DayType> DayList { get; set; }
    }
}
