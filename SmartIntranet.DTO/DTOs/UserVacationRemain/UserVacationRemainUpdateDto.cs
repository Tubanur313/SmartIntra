using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.ClauseDto
{
    public class UserVacationRemainUpdateDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal VacationCount { get; set; }
        public decimal UsedCount { get; set; }
        public decimal RemainCount { get; set; }
        public bool IsEditable { get; set; }
        public int AppUserId { get; set; }
        public IntranetUser AppUser { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
