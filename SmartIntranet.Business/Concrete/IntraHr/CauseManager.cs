using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class CauseManager : GenericManager<Cause>, ICauseService
    {
        private readonly IGenericDal<Cause> _genericDal;
        private readonly ICauseDal _causeDal;

        public CauseManager(IGenericDal<Cause> genericDal, ICauseDal causeDal) : base(genericDal)
        {
            _causeDal = causeDal;
            _genericDal = genericDal;
        }

        public async Task<List<Cause>> GetAllAsync(Expression<Func<Cause, bool>> filter)
        {
            return await _causeDal.GetAllAsync(filter);
        }

        public Task<List<Cause>> GetAllIncAsync()
        {
            return _causeDal.GetAllIncAsync();
        }

        public Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter)
        {
            return _causeDal.GetAllIncAsync(filter);
        }
    }
}
