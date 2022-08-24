using SmartIntranet.Entities.Concrete.IntraTicket;
using System;

namespace SmartIntranet.DTO.DTOs.TicketTripDtos.PermissionDtos
{
    public class PermissionUpdateDto
    {
        public string Reason { get; set; }
        public DateTime PermissionCreateDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public bool ConfirmSend { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
