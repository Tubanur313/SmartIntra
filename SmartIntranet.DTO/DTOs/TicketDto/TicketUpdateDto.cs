using System;
using System.Collections.Generic;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
        public bool Confirmed { get; set; }
        public IEnumerable<int> CheckListId { get; set; }
        public IEnumerable<int> AppUserWatcherId { get; set; }
        public IEnumerable<int> ConfirmTicketUserId { get; set; }
        public string OrderIds { get; set; }
        public int CategoryTicketId { get; set; }
        public CategoryTicket CategoryTicket { get; set; }
        public PriorityType PriorityType { get; set; }
        public StatusType StatusType { get; set; }
        public ICollection<TicketCheckList> TicketCheckLists { get; set; }
    }
}
