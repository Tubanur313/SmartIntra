using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class NonWorkingDayAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
    }
}
