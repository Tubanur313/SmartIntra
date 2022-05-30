using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class ClauseManager : GenericManager<Clause>, IClauseService
    {
        private readonly IGenericDal<Clause> _genericDal;
        private readonly IClauseDal _clauseDal;

        public ClauseManager(IGenericDal<Clause> genericDal, IClauseDal clauseyDal) : base(genericDal)
        {
            _clauseDal = clauseyDal;
            _genericDal = genericDal;
        }

        public async Task<List<Clause>> GetAllAsync(Expression<Func<Clause, bool>> filter)
        {
            return await _clauseDal.GetAllAsync(filter);
        }

        public Task<List<Clause>> GetAllIncCompAsync()
        {
            return _clauseDal.GetAllIncCompAsync();
        }

        public Task<List<Clause>> GetAllIncCompAsync(Expression<Func<Clause, bool>> filter)
        {
            return _clauseDal.GetAllIncCompAsync(filter);
        }
    }
}
