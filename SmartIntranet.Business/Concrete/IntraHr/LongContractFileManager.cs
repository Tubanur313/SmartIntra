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
    public class LongContractFileManager : GenericManager<LongContractFile>, ILongContractFileService
    {
        private readonly IGenericDal<LongContractFile> _genericDal;
        private readonly ILongContractFileDal _contractDal;

        public LongContractFileManager(IGenericDal<LongContractFile> genericDal, ILongContractFileDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<LongContractFile>> GetAllAsync(Expression<Func<LongContractFile, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<LongContractFile>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<LongContractFile>> GetAllIncCompAsync(Expression<Func<LongContractFile, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
