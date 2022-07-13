using System;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.TicketDto
{
    public class TicketListDto 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? DeadLineStart { get; set; }
        public DateTime? DeadLineEnd { get; set; }
        public bool Confirmed { get; set; }
        public int CategoryTicketId { get; set; }
        public CategoryTicket CategoryTicket { get; set; }
        public PriorityType PriorityType { get; set; }
        public StatusType StatusType { get; set; }
        public int EmployeeId { get; set; }
        public IntranetUser Employee { get; set; }
        public int? SupporterId { get; set; }
        public IntranetUser Supporter { get; set; }
        public BusinessTravel BusinessTravel { get; set; }
        public VacationLeave VacationLeave { get; set; }
        public Permission Permission { get; set; }
    }
}
