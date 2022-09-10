using System;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.NonWorkingDayDto
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
