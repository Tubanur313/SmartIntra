﻿using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.Entities.Concrete
{
    public class UserVacationRemain : BaseEntity
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FromDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ToDate { get; set; }
        public decimal VacationCount { get; set; }
        public decimal UsedCount { get; set; }
        public decimal RemainCount { get; set; }
        public bool IsEditable { get; set; }
        public int AppUserId { get; set; }
        public IntranetUser AppUser { get; set; }
    }
}
