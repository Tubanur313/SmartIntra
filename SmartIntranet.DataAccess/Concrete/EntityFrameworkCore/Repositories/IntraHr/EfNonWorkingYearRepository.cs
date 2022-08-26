using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNonWorkingYearRepository : EfGenericRepository<NonWorkingYear>, INonWorkingYearDal
    {
        public async Task<List<NonWorkingYear>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.NonWorkingYears.OrderByDescending(c => c.Year).ToListAsync();
        }

        public async Task<List<NonWorkingYear>> GetAllIncCompAsync(Expression<Func<NonWorkingYear, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.NonWorkingYears.Where(filter)
                .OrderByDescending(c => c.Year).ToListAsync();

        }
    }

}
