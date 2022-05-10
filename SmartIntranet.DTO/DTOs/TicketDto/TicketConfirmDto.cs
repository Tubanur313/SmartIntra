using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketConfirmDto
    {
        public int Id { get; set; }
        public List<int> ConfirmTicketUserId { get; set; }
        public bool Confirmed { get; set; }
        public ICollection<ConfirmTicketUser> ConfirmTicketUsers { get; set; }
    }
}
