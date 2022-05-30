using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class BusinessTripManager : GenericManager<BusinessTrip>, IBusinessTripService
    {
        private readonly IGenericDal<BusinessTrip> _genericDal;
        private readonly IBusinessTripDal _businessTripDal;

        public BusinessTripManager(IGenericDal<BusinessTrip> genericDal, IBusinessTripDal businessTripDal) : base(genericDal)
        {
            _businessTripDal = businessTripDal;
            _genericDal = genericDal;
        }

        public async Task<List<BusinessTrip>> GetAllAsync(Expression<Func<BusinessTrip, bool>> filter)
        {
            return await _businessTripDal.GetAllAsync(filter);
        }

        public Task<List<BusinessTrip>> GetAllIncAsync()
        {
            return _businessTripDal.GetAllIncAsync();
        }

        public Task<List<BusinessTrip>> GetAllIncAsync(Expression<Func<BusinessTrip, bool>> filter)
        {
            return _businessTripDal.GetAllIncAsync(filter);
        }
    }
}
