using SmartIntranet.DataAccess.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Business.Interfaces.IntraTicket;

namespace SmartIntranet.Business.Concrete.IntraTicket
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
