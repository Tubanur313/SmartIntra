using MimeKit;
using SmartIntranet.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IEmailService
    {
        void TicketSendEmail(int ticketId, TicketChangeType type, string UserFullName);
        //Task TicketSendEmailAsync(int ticketId, string ticketMessage, List<string> ToEmail);
    }
}
