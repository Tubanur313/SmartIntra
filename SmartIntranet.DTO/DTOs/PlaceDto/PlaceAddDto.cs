﻿using System;

namespace SmartIntranet.DTO.DTOs.PlaceDto
{
    public class PlaceAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public string Currency { get; set; }
    }
}
