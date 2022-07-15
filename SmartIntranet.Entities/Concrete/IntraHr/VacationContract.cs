using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class VacationContract : BaseEntity
    {
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
        public virtual ICollection<VacationContractFile> VacationContractFiles { get; set; }
        public virtual List<VacationContractDate> VacationContractDates { get; set; }
    }
}
