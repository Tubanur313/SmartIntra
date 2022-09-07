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
