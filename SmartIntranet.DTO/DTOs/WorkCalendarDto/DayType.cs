using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs
{
    public class DayType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int Day { get; set; }
        public bool IsActive { get; set; }
    }
}
