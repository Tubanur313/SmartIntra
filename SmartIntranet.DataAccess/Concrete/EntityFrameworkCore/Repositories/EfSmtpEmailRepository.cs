using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSmtpEmailRepository : EfGenericRepository<SMTPEmailSetting>, ISmtpEmailDal
    {
        public Task<SMTPEmailSetting> GetAsync()
        {
            using (var context = new IntranetContext())
            {
                return Task.FromResult(context.SMTPEmailSettings.FirstOrDefault());
            }

        }
    }
}
