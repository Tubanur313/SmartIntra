﻿using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.DTO.DTOs.FaqDto
{
    public class FaqUpdateDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string File { get; set; }
        public FaqCategory FaqCategory { get; set; }
    }
}
