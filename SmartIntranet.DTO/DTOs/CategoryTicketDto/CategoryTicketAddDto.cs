using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.CategoryTicketDto
{
    public class CategoryTicketAddDto 
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual CategoryTicket Parent { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
        public TicketType TicketType { get; set; }
    }
}
