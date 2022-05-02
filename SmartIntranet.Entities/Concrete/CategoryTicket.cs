using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete
{
    public class CategoryTicket : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual CategoryTicket Parent { get; set; }
        public virtual ICollection<CategoryTicket> Children { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public TicketType TicketType { get; set; }
    }
}
