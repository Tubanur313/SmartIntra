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
    public class CauseManager : GenericManager<Cause>, ICauseService
    {
        private readonly IGenericDal<Cause> _genericDal;
        private readonly ICauseDal _causeDal;

        public CauseManager(IGenericDal<Cause> genericDal, ICauseDal causeDal) : base(genericDal)
        {
            _causeDal = causeDal;
            _genericDal = genericDal;
        }

        public Task<List<Cause>> GetAllIncAsync(bool asnotrack = false)
        {
            return _causeDal.GetAllIncAsync(asnotrack);
        }

        public Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter, bool asnotrack = false)
        {
            return _causeDal.GetAllIncAsync(filter, asnotrack);
        }
    }
}
