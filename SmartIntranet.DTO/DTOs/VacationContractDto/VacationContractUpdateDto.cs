using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.PersonalContractDto
{
    public class VacationContractUpdateDto
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
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual List<VacationContractDate> VacationContractDates { get; set; }

    }
}
