using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class VacationContractDate : BaseEntity
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CalendarDay { get; set; }
        public int VacationId { get; set; }
        public VacationContract Vacation { get; set; }
    
    }
}
