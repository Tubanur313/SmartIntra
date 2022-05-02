using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;


namespace SmartIntranet.DTO.DTOs.WatcherDto
{
    public class WatcherAddDto
    {
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
    }
}
