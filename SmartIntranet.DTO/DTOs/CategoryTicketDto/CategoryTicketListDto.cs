
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DTO.DTOs.CategoryTicketDto
{
    public class CategoryTicketListDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual CategoryTicket Parent { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
        public TicketType TicketType { get; set; }
    }
}
