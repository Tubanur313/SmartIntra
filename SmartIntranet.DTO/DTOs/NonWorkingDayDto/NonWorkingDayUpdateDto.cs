using SmartIntranet.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class NonWorkingDayUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
    }
}
