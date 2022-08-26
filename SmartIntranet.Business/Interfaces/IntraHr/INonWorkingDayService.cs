using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface INonWorkingDayService : IGenericService<NonWorkingDay>
    {
        Task<List<NonWorkingDay>> GetAllIncCompAsync();
        Task<List<NonWorkingDay>> GetAllAsync(Expression<Func<NonWorkingDay, bool>> filter);
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter);
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter, int yearId);
    }
}
