using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketOrderDto
{
    public class TicketOrderListDto
    {
        public int Id { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
