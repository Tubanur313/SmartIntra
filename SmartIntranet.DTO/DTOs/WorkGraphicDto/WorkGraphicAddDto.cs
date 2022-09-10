using System;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.WorkGraphicDto
{
    public class WorkGraphicAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public string Description { get; set; }
        public int? NonWorkingYearId { get; set; }
        public WorkGraphic NonWorkingYear { get; set; }  
    }
}
