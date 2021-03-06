using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class ContractFileManager : GenericManager<ContractFile>, IContractFileService
    {
        private readonly IGenericDal<ContractFile> _genericDal;
        private readonly IContractFileDal _contractDal;

        public ContractFileManager(IGenericDal<ContractFile> genericDal, IContractFileDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<ContractFile>> GetAllAsync(Expression<Func<ContractFile, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<ContractFile>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<ContractFile>> GetAllIncCompAsync(Expression<Func<ContractFile, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
