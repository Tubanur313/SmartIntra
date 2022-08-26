using SmartIntranet.Core.Entities.Concrete;
using System;

namespace SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts
{
    public class Permission : BaseEntity
    {
        public string Reason { get; set; }
        public DateTime PermissionCreateDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
