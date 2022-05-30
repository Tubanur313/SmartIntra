using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Entities.Concrete
{
    public class BusinessTripUser: BaseEntity
    {
        public int BusinessTripId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlaceId { get; set; }
        public IntranetUser User { get; set; }
        public BusinessTrip BusinessTrip { get; set; }
        public Place Place { get; set; }
    }
}
