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
    public class WorkGraphicManager : GenericManager<WorkGraphic>, IWorkGraphicService
    {
        private readonly IGenericDal<WorkGraphic> _genericDal;
        private readonly IWorkGraphicDal _workGraphicDal;

        public WorkGraphicManager(IGenericDal<WorkGraphic> genericDal, IWorkGraphicDal workGraphicDal) : base(genericDal)
        {
            _workGraphicDal = workGraphicDal;
            _genericDal = genericDal;
        }

        public async Task<List<WorkGraphic>> GetAllAsync(Expression<Func<WorkGraphic, bool>> filter)
        {
            return await _workGraphicDal.GetAllAsync(filter);
        }

        public Task<List<WorkGraphic>> GetAllIncCompAsync()
        {
            return _workGraphicDal.GetAllIncCompAsync();
        }

        public Task<List<WorkGraphic>> GetAllIncCompAsync(Expression<Func<WorkGraphic, bool>> filter)
        {
            return _workGraphicDal.GetAllIncCompAsync(filter);
        }
    }
}
