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
    public class NonWorkingDayManager : GenericManager<NonWorkingDay>, INonWorkingDayService
    {
        private readonly IGenericDal<NonWorkingDay> _genericDal;
        private readonly INonWorkingDayDal _nonworkingdayDal;

        public NonWorkingDayManager(IGenericDal<NonWorkingDay> genericDal, INonWorkingDayDal nonworkingdayDal) : base(genericDal)
        {
            _nonworkingdayDal = nonworkingdayDal;
            _genericDal = genericDal;
        }

        public async Task<List<NonWorkingDay>> GetAllAsync(Expression<Func<NonWorkingDay, bool>> filter)
        {
            return await _nonworkingdayDal.GetAllAsync(filter);
        }

        public Task<List<NonWorkingDay>> GetAllIncCompAsync()
        {
            return _nonworkingdayDal.GetAllIncCompAsync();
        }

        public Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter)
        {
            return _nonworkingdayDal.GetAllIncCompAsync(filter);
        }

        public Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter, int yearId)
        {
            return _nonworkingdayDal.GetAllIncCompAsync(filter, yearId);
        }
    }
}
