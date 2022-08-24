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
    public class EfClauseRepository : EfGenericRepository<Clause>, IClauseDal
    {
        public async Task<List<Clause>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.Clauses.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<Clause>> GetAllIncCompAsync(Expression<Func<Clause, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Clauses.Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();
        }
    }
}
