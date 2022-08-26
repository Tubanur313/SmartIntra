using System;

namespace SmartIntranet.DTO.DTOs.PersonalContractDto
{
    public class UserVacationRemainDates
    {
        public decimal RemainCount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Message { get; set; }
    }
}
