using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface ICauseService : IGenericService<Cause>
    {
        Task<List<Cause>> GetAllIncAsync(bool asnotrack = false);
        Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter, bool asnotrack = false);
    }
}
