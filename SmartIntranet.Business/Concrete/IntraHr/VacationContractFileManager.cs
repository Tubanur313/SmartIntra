using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class VacationContractFileManager : GenericManager<VacationContractFile>, IVacationContractFileService
    {
        private readonly IGenericDal<VacationContractFile> _genericDal;
        private readonly IVacationContractFileDal _contractDal;

        public VacationContractFileManager(IGenericDal<VacationContractFile> genericDal, IVacationContractFileDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<VacationContractFile>> GetAllAsync(Expression<Func<VacationContractFile, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<VacationContractFile>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<VacationContractFile>> GetAllIncCompAsync(Expression<Func<VacationContractFile, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
