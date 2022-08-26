using SmartIntranet.Entities.Concrete;
using System;

namespace SmartIntranet.DTO.DTOs.TicketTripDtos.BusinessTravelDtos
{
    public class BusinessTravelAddDto
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
    }
}
