using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketCategoryDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
