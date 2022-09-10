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
    public class EfPlaceRepository : EfGenericRepository<Place>, IPlaceDal
    {
        public async Task<List<Place>> GetAllIncAsync()
        {
            await using var context = new IntranetContext();
            return await context.Places.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<Place>> GetAllIncAsync(Expression<Func<Place, bool>> filter, bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)
                return await context.Places.Where(filter)
                    .AsNoTracking().OrderByDescending(c => c.Name).ToListAsync();
            return await context.Places.Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();
        }
    }
}
