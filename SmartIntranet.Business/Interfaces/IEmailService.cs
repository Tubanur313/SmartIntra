using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IEmailService
    {
        void TicketSendEmail(int ticketId,string ticketMessage, List<string> ToEmail);
        //Task TicketSendEmailAsync(int ticketId);
    }
}
