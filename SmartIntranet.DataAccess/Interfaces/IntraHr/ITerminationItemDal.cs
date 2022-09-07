using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface ITerminationItemDal : IGenericDal<TerminationItem>
    {
        Task<List<TerminationItem>> GetAllIncCompAsync(); 
        Task<List<TerminationItem>> GetAllIncCompAsync(Expression<Func<TerminationItem, bool>> filter); 
    }
}
