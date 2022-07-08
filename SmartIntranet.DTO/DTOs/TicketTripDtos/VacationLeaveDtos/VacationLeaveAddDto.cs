using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TicketTripDtos.VacationLeaveDtos
{
    public class VacationLeaveAddDto
    {
        public VacationKind VacationKind { get; set; }
        public int Vacationlength { get; set; }
        public DateTime VacationCreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public bool ConfirmSend { get; set; }

    }
}
