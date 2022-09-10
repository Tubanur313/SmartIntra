using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface ITerminationItemService : IGenericService<TerminationItem>
    {
        Task<List<TerminationItem>> GetAllIncCompAsync();
        Task<List<TerminationItem>> GetAllAsync(Expression<Func<TerminationItem, bool>> filter);
        Task<List<TerminationItem>> GetAllIncCompAsync(Expression<Func<TerminationItem, bool>> filter);
    }
}
