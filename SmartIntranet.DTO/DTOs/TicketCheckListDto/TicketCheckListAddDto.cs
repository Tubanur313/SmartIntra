using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DTO.DTOs.TicketCheckListDto
{
    public class TicketCheckListAddDto
    {
        public int? CheckListId { get; set; }
        public CheckList CheckList { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
