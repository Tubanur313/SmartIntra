using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ISmtpEmailDal : IGenericDal<SMTPEmailSetting>
    {
        SMTPEmailSetting Get();
    }
}
