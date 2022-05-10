using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ISmtpEmailService : IGenericService<SMTPEmailSetting>
    {
        Task<SMTPEmailSetting> GetAsync();
    }
}
