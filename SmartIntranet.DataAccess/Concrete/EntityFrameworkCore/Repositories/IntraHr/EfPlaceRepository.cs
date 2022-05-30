using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPlaceRepository : EfGenericRepository<Place>, IPlaceDal
    {
        public async Task<List<Place>> GetAllIncAsync()
        {
            using var context = new IntranetContext();
            return await context.Places.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<Place>> GetAllIncAsync(Expression<Func<Place, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Places.Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();
        }
    }
}
