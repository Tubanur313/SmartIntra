using SmartIntranet.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketPriorityDto
    {
        public int Id { get; set; }
        public PriorityType PriorityType { get; set; }
    }
}
