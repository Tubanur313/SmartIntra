﻿using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{
  
    public class Photo : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
