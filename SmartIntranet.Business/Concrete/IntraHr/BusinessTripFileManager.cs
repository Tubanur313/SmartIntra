using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class BusinessTripFileManager : GenericManager<BusinessTripFile>, IBusinessTripFileService
    {
        private readonly IGenericDal<BusinessTripFile> _genericDal;
        private readonly IBusinessTripFileDal _businessTripFileDal;

        public BusinessTripFileManager(IGenericDal<BusinessTripFile> genericDal, IBusinessTripFileDal businessTripFileDal) : base(genericDal)
        {
            _businessTripFileDal = businessTripFileDal;
            _genericDal = genericDal;
        }

        public async Task<List<BusinessTripFile>> GetAllAsync(Expression<Func<BusinessTripFile, bool>> filter)
        {
            return await _businessTripFileDal.GetAllAsync(filter);
        }

        public Task<List<BusinessTripFile>> GetAllIncAsync()
        {
            return _businessTripFileDal.GetAllIncAsync();
        }

        public Task<List<BusinessTripFile>> GetAllIncAsync(Expression<Func<BusinessTripFile, bool>> filter)
        {
            return _businessTripFileDal.GetAllIncAsync(filter);
        }
    }
}
