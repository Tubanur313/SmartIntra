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
    public class ContractManager : GenericManager<Contract>, IContractService
    {
        private readonly IGenericDal<Contract> _genericDal;
        private readonly IContractDal _contractDal;

        public ContractManager(IGenericDal<Contract> genericDal, IContractDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<Contract>> GetAllAsync(Expression<Func<Contract, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<Contract>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<Contract>> GetAllIncCompAsync(Expression<Func<Contract, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }

        public Task<List<Contract>> GetAllIncCompAsync(int companyId, int departmentId, int positionId, string Interval)
        {
            return _contractDal.GetAllIncCompAsync(companyId, departmentId, positionId,Interval);
        }

        public Task<List<Contract>> GetAllIncCompAsync(int? compIdOfUser)
        {
            return _contractDal.GetAllIncCompAsync(compIdOfUser);
        }
    }
}
