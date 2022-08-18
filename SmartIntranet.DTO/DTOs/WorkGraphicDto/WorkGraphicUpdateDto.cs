using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.WorkGraphicDto
{
    public class WorkGraphicUpdateDto
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
        public string Key { get; set; }
        public string Description { get; set; }
        public int? NonWorkingYearId { get; set; }
        public WorkGraphic NonWorkingYear { get; set; }
    }
}
