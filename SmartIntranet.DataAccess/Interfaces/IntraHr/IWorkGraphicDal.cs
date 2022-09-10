using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IWorkGraphicDal : IGenericDal<WorkGraphic>
    {
        Task<List<WorkGraphic>> GetAllIncCompAsync(); 
        Task<List<WorkGraphic>> GetAllIncCompAsync(Expression<Func<WorkGraphic, bool>> filter); 
    }
}
