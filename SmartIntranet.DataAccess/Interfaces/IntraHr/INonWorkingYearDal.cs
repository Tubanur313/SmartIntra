using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface INonWorkingYearDal : IGenericDal<NonWorkingYear>
    {
        Task<List<NonWorkingYear>> GetAllIncCompAsync(); 
        Task<List<NonWorkingYear>> GetAllIncCompAsync(Expression<Func<NonWorkingYear, bool>> filter); 
    }
}
