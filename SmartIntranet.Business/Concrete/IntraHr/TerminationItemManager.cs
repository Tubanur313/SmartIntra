using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class TerminationItemManager : GenericManager<TerminationItem>, ITerminationItemService
    {
        private readonly IGenericDal<TerminationItem> _genericDal;
        private readonly ITerminationItemDal _contractDal;

        public TerminationItemManager(IGenericDal<TerminationItem> genericDal, ITerminationItemDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<TerminationItem>> GetAllAsync(Expression<Func<TerminationItem, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<TerminationItem>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<TerminationItem>> GetAllIncCompAsync(Expression<Func<TerminationItem, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
