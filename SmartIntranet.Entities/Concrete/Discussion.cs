using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete
{
   
    public class Discussion : BaseEntity
    {
        public string Content { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
