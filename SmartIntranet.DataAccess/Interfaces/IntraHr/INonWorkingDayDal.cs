using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface INonWorkingDayDal : IGenericDal<NonWorkingDay>
    {
        Task<List<NonWorkingDay>> GetAllIncCompAsync(); 
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter);
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter, int yearId);
    }
}
