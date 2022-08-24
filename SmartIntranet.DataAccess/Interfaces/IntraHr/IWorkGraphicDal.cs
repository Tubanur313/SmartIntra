using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IWorkGraphicDal : IGenericDal<WorkGraphic>
    {
        Task<List<WorkGraphic>> GetAllIncCompAsync(); 
        Task<List<WorkGraphic>> GetAllIncCompAsync(Expression<Func<WorkGraphic, bool>> filter); 
    }
}
