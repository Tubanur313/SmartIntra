using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Business.Concrete;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.Business.Concrete
{
    public class WatcherManager : GenericManager<Watcher>, IWatcherService
    {
        private readonly IGenericDal<Watcher> _genericDal;
        private readonly IWatcherDal _watcherDal;

        public WatcherManager(IGenericDal<Watcher> genericDal, IWatcherDal watcherDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _watcherDal = watcherDal;
        }
        public async Task<List<Watcher>> MyWatchedTicketsAsync(int userId)
        {
            return await _watcherDal.MyWatchedTicketsAsync(userId);
        }
        public async Task<List<Watcher>> MyWatchedTicketsAsync(int userId, int categoryId, StatusType statusType)
        {
            return await _watcherDal.MyWatchedTicketsAsync( userId,  categoryId, statusType);
        }

    }
}
