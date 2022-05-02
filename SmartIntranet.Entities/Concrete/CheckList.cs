using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Entities.Concrete
{
    public class CheckList : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TicketCheckList> TicketCheckLists { get; set; }
    }
}
