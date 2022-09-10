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
