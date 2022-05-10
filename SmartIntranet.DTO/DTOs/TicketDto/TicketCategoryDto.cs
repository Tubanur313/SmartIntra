using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketCategoryDto
    {
        public int Id { get; set; }
        public int CategoryTicketId { get; set; }
        public CategoryTicket CategoryTicket { get; set; }
    }
}
