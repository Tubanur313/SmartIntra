﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.BusinessTripDto
{
    public class BusinessTripUpdateDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CommandNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CommandDate { get; set; }
        public int CauseId { get; set; }
        public bool IsTransportation { get; set; }
        public bool IsHotelDemand { get; set; }
        public virtual List<BusinessTripUser> BusinessTripUsers { get; set; }
    }
}
