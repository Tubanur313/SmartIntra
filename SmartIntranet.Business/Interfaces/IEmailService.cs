using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.Business.Interfaces
{
    public interface IEmailService
    {
        void TicketSendEmail(int ticketId, TicketChangeType type, string userFullName);
        //Task TicketSendEmailAsync(int ticketId, string ticketMessage, List<string> ToEmail);
        void ContactSendEmail(string userFullName,string company, string department, string position, string userProfile);
        void ContactChangeSendEmail(string userCFullname, string usrName,string gender, string companyName, string positionName);
    }
}
