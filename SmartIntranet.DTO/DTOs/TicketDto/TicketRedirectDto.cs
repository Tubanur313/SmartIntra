using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketRedirectDto
    {
        public int Id { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
    }
}
