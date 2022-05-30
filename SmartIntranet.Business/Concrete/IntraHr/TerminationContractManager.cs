using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class TerminationContractManager : GenericManager<TerminationContract>, ITerminationContractService
    {
        private readonly IGenericDal<TerminationContract> _genericDal;
        private readonly ITerminationContractDal _contractDal;

        public TerminationContractManager(IGenericDal<TerminationContract> genericDal, ITerminationContractDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<TerminationContract>> GetAllAsync(Expression<Func<TerminationContract, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<TerminationContract>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<TerminationContract>> GetAllIncCompAsync(Expression<Func<TerminationContract, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
