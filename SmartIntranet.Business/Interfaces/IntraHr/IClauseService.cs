using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IClauseService : IGenericService<Clause>
    {
        Task<List<Clause>> GetAllIncCompAsync();
        Task<List<Clause>> GetAllAsync(Expression<Func<Clause, bool>> filter);
        Task<List<Clause>> GetAllIncCompAsync(Expression<Func<Clause, bool>> filter);
    }
}
