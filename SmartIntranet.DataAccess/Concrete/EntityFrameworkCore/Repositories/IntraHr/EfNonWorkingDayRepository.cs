using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraHr
{
    public class EfNonWorkingDayRepository : EfGenericRepository<NonWorkingDay>, INonWorkingDayDal
    {
        public async Task<List<NonWorkingDay>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.NonWorkingDays.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.NonWorkingDays.Include(x=>x.NonWorkingYear).Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();

        }

        public async Task<List<NonWorkingDay>> GetAllIncCompAsync(Expression<Func<NonWorkingDay, bool>> filter, int yearId)
        {
            using var context = new IntranetContext();
            return await context.NonWorkingDays.Where(x => x.NonWorkingYearId == yearId).Where(filter).OrderBy(c => c.StartDate).ToListAsync();

        }

    }

}
