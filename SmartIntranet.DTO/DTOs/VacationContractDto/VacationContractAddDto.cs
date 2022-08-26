using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.PersonalContractDto
{
    public class VacationContractAddDto
    {
        public int Id { get; set; }
        public string Description { get; set; } // emrin esasi
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CalendarDay { get; set; }
        public DateTime NextWorkDate { get; set; }
        public string CommandNumber { get; set; }
        public DateTime CommandDate { get; set; }
        public int UserId { get; set; }
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }
        public IntranetUser User { get; set; }
        public virtual List<VacationContractDate> VacationContractDates { get; set; }
    }
}
