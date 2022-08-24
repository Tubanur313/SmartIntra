using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;

namespace SmartIntranet.DTO.DTOs.TicketTripDtos.BusinessTravelDtos
{
    public class BusinessTravelUpdateDto
    {
        public bool Transport { get; set; }
        public bool Accommodation { get; set; }
        public bool ConfirmSend { get; set; }
        public int Staylength { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
        public int? CauseId { get; set; }
        public Cause Cause { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
