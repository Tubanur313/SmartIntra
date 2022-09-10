using System;
using System.Collections.Generic;
using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class BusinessTrip: BaseEntity
    {
        public int CompanyId { get; set; }
        public string CommandNumber { get; set; }
        public DateTime CommandDate { get; set; }
        public int CauseId { get; set; }
        public bool IsTransportation { get; set; }
        public bool IsHotelDemand { get; set; }
        public virtual ICollection<BusinessTripUser> BusinessTripUsers { get; set; }
    }
}
