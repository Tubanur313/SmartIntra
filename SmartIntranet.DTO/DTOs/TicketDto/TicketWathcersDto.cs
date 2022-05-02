using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketWathcersDto
    {
        public int Id { get; set; }
        public List<int> AppUserWatcherId { get; set; }
        public ICollection<Watcher> Watchers { get; set; }
    }
}
