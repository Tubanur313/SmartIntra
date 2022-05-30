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
    public class EfBusinessTripRepository : EfGenericRepository<BusinessTrip>, IBusinessTripDal
    {
        public async Task<List<BusinessTrip>> GetAllIncAsync()
        {
            using var context = new IntranetContext();
            return await context.BusinessTrips.OrderByDescending(c => c.Id).ToListAsync();
        }

        public async Task<List<BusinessTrip>> GetAllIncAsync(Expression<Func<BusinessTrip, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.BusinessTrips.Include(x => x.BusinessTripUsers).Where(filter)
                .OrderByDescending(c => c.Id).ToListAsync();
        }
    }
}
