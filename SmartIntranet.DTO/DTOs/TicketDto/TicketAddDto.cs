using System;
using System.Collections.Generic;
using System.Text;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketAddDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
        public bool Confirmed { get; set; }
        public List<int> CheckListId { get; set; }
        public List<int> AppUserWatcherId { get; set; }
        public List<int> ConfirmTicketUserId { get; set; }
        public string OrderIds { get; set; }
        public string GrandTotal { get; set; }
        public int TicketCategoryId { get; set; }
        public PriorityType PriorityType { get; set; }
        public StatusType StatusType { get; set; }
    }
}
