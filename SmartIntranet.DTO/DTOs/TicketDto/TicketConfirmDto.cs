using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;

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
