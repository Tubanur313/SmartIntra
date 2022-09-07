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
    public class ContractTypeManager : GenericManager<ContractType>, IContractTypeService
    {
        private readonly IGenericDal<ContractType> _genericDal;
        private readonly IContractTypeDal _contractDal;

        public ContractTypeManager(IGenericDal<ContractType> genericDal, IContractTypeDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<ContractType>> GetAllAsync(Expression<Func<ContractType, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<ContractType>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<ContractType>> GetAllIncCompAsync(Expression<Func<ContractType, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
