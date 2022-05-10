﻿using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DTO.DTOs.TicketOrderDto
{
    public class TicketOrderAddDto
    {
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
