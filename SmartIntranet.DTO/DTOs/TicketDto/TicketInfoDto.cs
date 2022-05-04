using System;
using System.Collections.Generic;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? DeadLineEnd { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Confirmed { get; set; }
        public IEnumerable<int> CheckListId { get; set; }
        public IEnumerable<int> AppUserWatcherId { get; set; }
        public IEnumerable<int> ConfirmTicketUserId { get; set; }
        public string OrderIds { get; set; }
        public int CategoryTicketId { get; set; }
        public CategoryTicket CategoryTicket { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
        public int? EmployeeId { get; set; }
        public IntranetUser Employee { get; set; }
        public PriorityType PriorityType { get; set; }
        public StatusType StatusType { get; set; }
        public ICollection<TicketCheckList> TicketCheckLists { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<TicketOrder> TicketOrders { get; set; }
        public ICollection<Discussion> Discussions { get; set; }
    }
}
