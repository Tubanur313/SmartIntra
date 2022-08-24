using System;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class NonWorkingYearUpdateDto
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
