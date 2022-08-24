using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.Business.Interfaces
{
    public interface IEmailService
    {
        void TicketSendEmail(int ticketId, TicketChangeType type, string UserFullName);
        //Task TicketSendEmailAsync(int ticketId, string ticketMessage, List<string> ToEmail);
    }
}
