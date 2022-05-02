using SmartIntranet.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketStatusDto
    {
        public int Id { get; set; }
        public StatusType StatusType { get; set; }
    }
}
