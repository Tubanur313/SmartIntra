using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface INonWorkingDayService : IGenericService<NonWorkingDay>
    {
        Task<List<NonWorkingDay>> GetAllIncCompAsync();
        Task<List<NonWorkingDay>> GetAllAsync(Expression<Func<NonWorkingDay, bool>> filter);
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter);
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter, int yearId);
    }
}
