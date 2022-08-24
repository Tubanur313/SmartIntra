﻿using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{

    public class TicketOrder :BaseEntity
    {
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
