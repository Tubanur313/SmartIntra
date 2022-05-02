using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DTO.DTOs.WatcherDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface IWatcherService : IGenericService<Watcher>
    {
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId,int categoryId,StatusType statusType);
        Task<List<Watcher>> MyWatchedTicketsAsync(int userId);
    }
}
