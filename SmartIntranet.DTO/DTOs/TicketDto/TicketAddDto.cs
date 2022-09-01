using System.Collections.Generic;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DTO.DTOs.TicketTripDtos.BusinessTravelDtos;
using SmartIntranet.DTO.DTOs.TicketTripDtos.PermissionDtos;
using SmartIntranet.DTO.DTOs.TicketTripDtos.VacationLeaveDtos;

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
        public List<int> BusinessTravelPlaceId { get; set; }
        public string OrderIds { get; set; }
        public string GrandTotal { get; set; }
        public int TicketCategoryId { get; set; }
        public PriorityType PriorityType { get; set; }
        public StatusType StatusType { get; set; }
        public BusinessTravelAddDto BusinessTravelAddDto { get; set; }
        public VacationLeaveAddDto VacationLeaveAddDto { get; set; }
        public PermissionAddDto PermissionAddDto { get; set; }
    }
}
