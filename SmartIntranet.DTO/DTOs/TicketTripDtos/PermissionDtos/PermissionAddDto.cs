using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketTripDtos.PermissionDtos
{
    public class PermissionAddDto
    {
        public string Reason { get; set; }
        public DateTime PermissionCreateDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public bool ConfirmSend { get; set; }

    }
}
