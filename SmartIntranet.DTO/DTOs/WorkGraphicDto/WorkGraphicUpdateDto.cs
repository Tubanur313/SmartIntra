using System;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.WorkGraphicDto
{
    public class WorkGraphicUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public int? NonWorkingYearId { get; set; }
        public WorkGraphic NonWorkingYear { get; set; }
    }
}
