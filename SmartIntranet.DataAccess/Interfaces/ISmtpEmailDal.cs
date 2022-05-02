using SmartIntranet.Entities.Concrete;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ISmtpEmailDal : IGenericDal<SMTPEmailSetting>
    {
        Task<SMTPEmailSetting> GetAsync();
    }
}
