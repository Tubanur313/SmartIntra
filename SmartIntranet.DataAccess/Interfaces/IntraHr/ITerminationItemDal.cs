using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITerminationItemDal : IGenericDal<TerminationItem>
    {
        Task<List<TerminationItem>> GetAllIncCompAsync(); 
        Task<List<TerminationItem>> GetAllIncCompAsync(Expression<Func<TerminationItem, bool>> filter); 
    }
}
