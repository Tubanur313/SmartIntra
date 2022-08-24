using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;

namespace SmartIntranet.DTO.DTOs.DiscussionDto
{
    public class DiscussionListDto 
    {
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? IntranetUserId { get; set; }
        public AppUserDetailsDto IntranetUser { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
