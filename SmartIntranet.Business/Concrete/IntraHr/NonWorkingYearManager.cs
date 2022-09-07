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
    public class NonWorkingYearManager : GenericManager<NonWorkingYear>, INonWOrkingYearService
    {
        private readonly IGenericDal<NonWorkingYear> _genericDal;
        private readonly INonWorkingYearDal _nonWorkingYearDal;

        public NonWorkingYearManager(IGenericDal<NonWorkingYear> genericDal, INonWorkingYearDal nonWorkingYearDal) : base(genericDal)
        {
            _nonWorkingYearDal = nonWorkingYearDal;
            _genericDal = genericDal;
        }

        public async Task<List<NonWorkingYear>> GetAllAsync(Expression<Func<NonWorkingYear, bool>> filter)
        {
            return await _nonWorkingYearDal.GetAllAsync(filter);
        }

        public Task<List<NonWorkingYear>> GetAllIncCompAsync()
        {
            return _nonWorkingYearDal.GetAllIncCompAsync();
        }

        public Task<List<NonWorkingYear>> GetAllIncCompAsync(Expression<Func<NonWorkingYear, bool>> filter)
        {
            return _nonWorkingYearDal.GetAllIncCompAsync(filter);
        }
    }
}
