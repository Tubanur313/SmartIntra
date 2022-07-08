using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Core.Entities.Enum;
using System;

namespace SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts
{
    public class VacationLeave : BaseEntity
    {
        public VacationKind VacationKind { get; set; }
        public int Vacationlength { get; set; }
        public DateTime VacationCreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
