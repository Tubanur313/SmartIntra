using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ITerminationItemService : IGenericService<TerminationItem>
    {
        Task<List<TerminationItem>> GetAllIncCompAsync();
        Task<List<TerminationItem>> GetAllAsync(Expression<Func<TerminationItem, bool>> filter);
        Task<List<TerminationItem>> GetAllIncCompAsync(Expression<Func<TerminationItem, bool>> filter);
    }
}
