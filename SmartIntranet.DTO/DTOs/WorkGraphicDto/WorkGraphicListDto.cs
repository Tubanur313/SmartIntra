using System;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.WorkGraphicDto
{
    public class WorkGraphicListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public decimal Monday { get; set; }
        public decimal Tuesday { get; set; }
        public decimal Wednesday { get; set; }
        public decimal Thursday { get; set; }
        public decimal Friday { get; set; }
        public decimal Saturday { get; set; }
        public int Sunday { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public string Description { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
