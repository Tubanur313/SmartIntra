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
    public class TerminationContractFileManager : GenericManager<TerminationContractFile>, ITerminationContractFileService
    {
        private readonly IGenericDal<TerminationContractFile> _genericDal;
        private readonly ITerminationContractFileDal _contractDal;

        public TerminationContractFileManager(IGenericDal<TerminationContractFile> genericDal, ITerminationContractFileDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<TerminationContractFile>> GetAllAsync(Expression<Func<TerminationContractFile, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<TerminationContractFile>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<TerminationContractFile>> GetAllIncCompAsync(Expression<Func<TerminationContractFile, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
