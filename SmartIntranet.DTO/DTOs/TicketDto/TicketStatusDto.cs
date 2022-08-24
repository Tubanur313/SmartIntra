using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketStatusDto
    {
        public int Id { get; set; }
        public StatusType StatusType { get; set; }
    }
}
