using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface INonWorkingDayDal : IGenericDal<NonWorkingDay>
    {
        Task<List<NonWorkingDay>> GetAllIncCompAsync(); 
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter);
        Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter, int yearId);
    }
}
