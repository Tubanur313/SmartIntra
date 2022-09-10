using System;

namespace SmartIntranet.DTO.DTOs.NonWorkingYearDto
{
    public class NonWorkingYearListDto
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
