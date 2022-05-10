
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.ConfirmTicketUserDto
{
    public class ConfirmTicketUserAddDto
    {
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public bool ConfirmTicket { get; set; }
    }
}
