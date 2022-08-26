using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketRedirectDto
    {
        public int Id { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
    }
}
