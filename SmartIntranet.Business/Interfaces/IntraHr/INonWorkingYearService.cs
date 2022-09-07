using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface INonWOrkingYearService : IGenericService<NonWorkingYear>
    {
        Task<List<NonWorkingYear>> GetAllIncCompAsync();
        Task<List<NonWorkingYear>> GetAllAsync(Expression<Func<NonWorkingYear, bool>> filter);
        Task<List<NonWorkingYear>> GetAllIncCompAsync(Expression<Func<NonWorkingYear, bool>> filter);
    }
}
