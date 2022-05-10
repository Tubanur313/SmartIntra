using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketWathcersDto
    {
        public int Id { get; set; }
        public List<int> AppUserWatcherId { get; set; }
        public ICollection<Watcher> Watchers { get; set; }
    }
}
