using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IClauseService : IGenericService<Clause>
    {
        Task<List<Clause>> GetAllIncCompAsync();
        Task<List<Clause>> GetAllAsync(Expression<Func<Clause, bool>> filter);
        Task<List<Clause>> GetAllIncCompAsync(Expression<Func<Clause, bool>> filter);
    }
}
