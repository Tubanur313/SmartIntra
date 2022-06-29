using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ISmtpEmailDal : IGenericDal<SMTPEmailSetting>
    {
        SMTPEmailSetting Get();
    }
}
