using SmartIntranet.DataAccess.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket
{
    public class EfEntranceRepository : EfGenericRepository<Entrance>, IEntranceDal
    {
    }
}
