using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket
{
    public interface IWatcherDal : IGenericDal<Watcher>
    {
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId, int categoryId, StatusType statusType);
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId);
    }
}
