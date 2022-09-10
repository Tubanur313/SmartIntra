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
    public class LongContractManager : GenericManager<LongContract>, ILongContractService
    {
        private readonly IGenericDal<LongContract> _genericDal;
        private readonly ILongContractDal _contractDal;

        public LongContractManager(IGenericDal<LongContract> genericDal, ILongContractDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<LongContract>> GetAllAsync(Expression<Func<LongContract, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<LongContract>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<LongContract>> GetAllIncCompAsync(Expression<Func<LongContract, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
