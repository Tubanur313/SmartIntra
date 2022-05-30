using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Business.Concrete;

namespace SmartIntranet.Business.Concrete
{
    public class VacationTypeManager : GenericManager<VacationType>, IVacationTypeService
    {
        private readonly IGenericDal<VacationType> _genericDal;
        private readonly IVacationTypeDal _contractDal;

        public VacationTypeManager(IGenericDal<VacationType> genericDal, IVacationTypeDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<VacationType>> GetAllAsync(Expression<Func<VacationType, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<VacationType>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<VacationType>> GetAllIncCompAsync(Expression<Func<VacationType, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
