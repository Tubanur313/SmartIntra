using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete
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
