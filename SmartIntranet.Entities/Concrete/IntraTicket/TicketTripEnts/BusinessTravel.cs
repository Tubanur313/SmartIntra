using SmartIntranet.Core.Entities.Concrete;
using System;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts
{
    public class BusinessTravel:BaseEntity
    {
        public bool Transport { get; set; }
        public bool Accommodation { get; set; }
        public int Staylength { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
        public int CauseId { get; set; }
        public Cause Cause { get; set; }

    }
}
