using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSmtpEmailRepository : EfGenericRepository<SMTPEmailSetting>, ISmtpEmailDal
    {
        public  async Task<SMTPEmailSetting> GetAsync()
        {
            using var context = new IntranetContext();
            return context.SMTPEmailSettings.FirstOrDefault();
        }
    }
}
