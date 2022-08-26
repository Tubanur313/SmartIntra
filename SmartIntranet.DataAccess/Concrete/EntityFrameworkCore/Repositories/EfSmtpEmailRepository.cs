using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Linq;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSmtpEmailRepository : EfGenericRepository<SMTPEmailSetting>, ISmtpEmailDal
    {
        public SMTPEmailSetting Get()
        {
            using (var context = new IntranetContext())
            {
                return context.SMTPEmailSettings.FirstOrDefault();
            }

        }
    }
}
