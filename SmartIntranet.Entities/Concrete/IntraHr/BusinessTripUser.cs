﻿using System;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class BusinessTripUser: BaseEntity
    {
        public int BusinessTripId { get; set; }
        public int UserId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }
        public int PlaceId { get; set; }
        public IntranetUser User { get; set; }
        public BusinessTrip BusinessTrip { get; set; }
        public Place Place { get; set; }
    }
}
