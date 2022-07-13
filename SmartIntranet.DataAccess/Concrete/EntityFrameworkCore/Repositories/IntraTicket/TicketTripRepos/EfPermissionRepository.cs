using SmartIntranet.DataAccess.Interfaces.IntraTicket.TicketTripDals;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket.TicketTripRepos
{
    public class EfPermissionRepository : EfGenericRepository<Permission>, IPermissionDal
    {
    }
}
