﻿using SmartIntranet.Core.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.Entities.Concrete
{
    public class VacationContractDate : BaseEntity
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FromDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ToDate { get; set; }
        public int CalendarDay { get; set; }
        public int VacationId { get; set; }
        public VacationContract Vacation { get; set; }
    }
}
