using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Entities.Concrete.IntraHr;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.VacationContractDto
{
    public class VacationContractUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; } // emrin esasi
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FromDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ToDate { get; set; }
        public int CalendarDay { get; set; }
        public DateTime NextWorkDate { get; set; }
        public string CommandNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CommandDate { get; set; }
        public int UserId { get; set; }
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }
        public IntranetUser User { get; set; }
        public virtual List<VacationContractDate> VacationContractDates { get; set; }

    }
}
