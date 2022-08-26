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
    public class EfCauseRepository : EfGenericRepository<Cause>, ICauseDal
    {
        public async Task<List<Cause>> GetAllIncAsync()
        {
            using var context = new IntranetContext();
            return await context.Causes.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Causes.Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();
        }
    }
}
