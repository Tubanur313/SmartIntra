using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketCheklistDto
    {
        public int Id { get; set; }
        public List<int> CheckListId { get; set; }
        public ICollection<TicketCheckList> TicketCheckLists { get; set; }
    }
}
