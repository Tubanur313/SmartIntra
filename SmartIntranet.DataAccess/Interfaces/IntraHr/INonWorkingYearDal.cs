using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface INonWorkingYearDal : IGenericDal<NonWorkingYear>
    {
        Task<List<NonWorkingYear>> GetAllIncCompAsync(); 
        Task<List<NonWorkingYear>> GetAllIncCompAsync(Expression<Func<NonWorkingYear, bool>> filter); 
    }
}
