using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IWatcherDal : IGenericDal<Watcher>
    {
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId, int categoryId, StatusType statusType);
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId);
    }
}
