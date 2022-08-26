using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketPriorityDto
    {
        public int Id { get; set; }
        public PriorityType PriorityType { get; set; }
    }
}
