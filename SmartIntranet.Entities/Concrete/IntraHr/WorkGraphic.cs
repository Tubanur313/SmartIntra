using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class WorkGraphic : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public string Description { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
        public virtual ICollection<WorkCalendar> WorkCalendars { get; set; }
    }
}
