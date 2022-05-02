using System;


namespace SmartIntranet.DTO.DTOs.GradeDto
{
    public class GradeListDto
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
