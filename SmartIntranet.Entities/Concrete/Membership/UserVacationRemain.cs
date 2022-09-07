using System;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class UserVacationRemain : BaseEntity
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FromDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ToDate { get; set; }
        public decimal VacationCount { get; set; }
        public decimal UsedCount { get; set; }
        public decimal RemainCount { get; set; }
        public bool IsEditable { get; set; }
        public int AppUserId { get; set; }
        public IntranetUser AppUser { get; set; }
    }
}
