using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces
{
    public interface ISmtpEmailService : IGenericService<SMTPEmailSetting>
    {
        SMTPEmailSetting Get();
    }
}
