
using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{
    public class TicketCheckList:BaseEntity
    {
        public int? CheckListId { get; set; }
        public CheckList CheckList { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public bool Confirm { get; set; }
    }
}
