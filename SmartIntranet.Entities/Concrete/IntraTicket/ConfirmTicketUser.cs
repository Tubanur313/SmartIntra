using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{
    public class ConfirmTicketUser : BaseEntity
    {
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public bool ConfirmTicket { get; set; }
    }
}
