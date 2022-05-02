using SmartIntranet.Entities.Concrete;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ISmtpEmailService : IGenericService<SMTPEmailSetting>
    {
        Task<SMTPEmailSetting> GetAsync();
    }
}
