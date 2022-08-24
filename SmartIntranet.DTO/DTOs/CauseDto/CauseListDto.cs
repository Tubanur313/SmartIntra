using System;

namespace SmartIntranet.DTO.DTOs.CauseDto
{
    public class CauseListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
