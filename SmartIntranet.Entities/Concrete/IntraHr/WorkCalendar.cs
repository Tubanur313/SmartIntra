using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class WorkCalendar : BaseEntity
    {
        public int Number { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public int? WorkGraphicId { get; set; }
        public WorkGraphic WorkGraphic { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
    }
}
