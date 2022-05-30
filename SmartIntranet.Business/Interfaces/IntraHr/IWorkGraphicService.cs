using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IWorkGraphicService : IGenericService<WorkGraphic>
    {
        Task<List<WorkGraphic>> GetAllIncCompAsync();
        Task<List<WorkGraphic>> GetAllAsync(Expression<Func<WorkGraphic, bool>> filter);
        Task<List<WorkGraphic>> GetAllIncCompAsync(Expression<Func<WorkGraphic, bool>> filter);
    }
}
