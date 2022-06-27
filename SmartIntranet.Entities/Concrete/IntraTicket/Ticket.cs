using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{

    public class Ticket : BaseEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? OpenDate { get; set; } = DateTime.Now;
        public DateTime? CloseDate { get; set; }
        public DateTime? DeadLineStart { get; set; }
        public DateTime? DeadLineEnd { get; set; }
        public bool Confirmed { get; set; }

        public int? CategoryTicketId { get; set; }
        public CategoryTicket CategoryTicket { get; set; }
        public PriorityType PriorityType { get; set; }
        public StatusType StatusType { get; set; }
        public int? EmployeeId { get; set; }
        public IntranetUser Employee { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
        public string OrderPath { get; set; }
        public string GrandTotal { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Watcher> Watchers { get; set; }
        public virtual ICollection<TicketOrder> TicketOrders { get; set; }
        public virtual ICollection<TicketCheckList> TicketCheckLists { get; set; }
        public virtual ICollection<ConfirmTicketUser> ConfirmTicketUsers { get; set; }
    }
}
