using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.BusinessTripDto
{
    public class BusinessTripUpdateDto
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
