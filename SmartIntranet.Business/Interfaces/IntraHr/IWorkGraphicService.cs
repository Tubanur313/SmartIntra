using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IWorkGraphicService : IGenericService<WorkGraphic>
    {
        Task<List<WorkGraphic>> GetAllIncCompAsync();
        Task<List<WorkGraphic>> GetAllAsync(Expression<Func<WorkGraphic, bool>> filter);
        Task<List<WorkGraphic>> GetAllIncCompAsync(Expression<Func<WorkGraphic, bool>> filter);
    }
}
