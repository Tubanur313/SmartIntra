using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Linq;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class SettingsRepository : EfGenericRepository<Settings>, ISettingsDal
    {
        public Settings Get()
        {
            using var context = new IntranetContext();
            return context.Settings.FirstOrDefault();
        }
    }
}
