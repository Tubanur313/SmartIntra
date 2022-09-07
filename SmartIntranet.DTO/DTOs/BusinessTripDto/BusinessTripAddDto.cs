using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.BusinessTripDto
{
    public class BusinessTripAddDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CommandNumber { get; set; }
        public DateTime CommandDate { get; set; }
        public int CauseId { get; set; }
        public bool IsTransportation { get; set; }
        public bool IsHotelDemand { get; set; }
        public virtual List<BusinessTripUser> BusinessTripUsers { get; set; }
    }
}
