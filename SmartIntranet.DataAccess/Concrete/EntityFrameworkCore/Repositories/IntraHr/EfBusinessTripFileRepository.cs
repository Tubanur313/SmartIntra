using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBusinessTripFileRepository : EfGenericRepository<BusinessTripFile>, IBusinessTripFileDal
    {
        public async Task<List<BusinessTripFile>> GetAllIncAsync()
        {
            using var context = new IntranetContext();
            return await context.BusinessTripFiles.Include(x => x.Clause).ToListAsync();
        }

        public async Task<List<BusinessTripFile>> GetAllIncAsync(Expression<Func<BusinessTripFile, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.BusinessTripFiles.Include(x=>x.Clause).Where(filter).ToListAsync();
        }
    }

}
