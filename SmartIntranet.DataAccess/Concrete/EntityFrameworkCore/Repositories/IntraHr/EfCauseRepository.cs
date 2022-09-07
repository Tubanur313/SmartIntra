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
    public class EfCauseRepository : EfGenericRepository<Cause>, ICauseDal
    {
        public async Task<List<Cause>> GetAllIncAsync(bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)
                return await context.Causes.OrderByDescending(c => c.Name).AsNoTracking().ToListAsync();
            return await context.Causes.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter, bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)
                return await context.Causes.Where(filter)
                .OrderByDescending(c => c.Name).AsNoTracking().ToListAsync();
            return await context.Causes.Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();
        }
    }
}
