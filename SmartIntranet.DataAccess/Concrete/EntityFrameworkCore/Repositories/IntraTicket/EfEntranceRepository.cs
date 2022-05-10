using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfEntranceRepository : EfGenericRepository<Entrance>, IEntranceDal
    {
    }
}
