﻿using SmartIntranet.Core.Entities.Concrete;
using System;


namespace SmartIntranet.Entities.Concrete
{
    public class NonWorkingDay : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
    }
}
