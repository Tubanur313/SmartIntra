using SmartIntranet.Core.Entities.Concrete;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{
    public class CheckList : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TicketCheckList> TicketCheckLists { get; set; }
    }
}
