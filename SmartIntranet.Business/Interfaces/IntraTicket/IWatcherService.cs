using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface IWatcherService : IGenericService<Watcher>
    {
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId,int categoryId,StatusType statusType);
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId);
    }
}
