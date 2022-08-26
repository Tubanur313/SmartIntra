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
    public class EfTerminationItemRepository : EfGenericRepository<TerminationItem>, ITerminationItemDal
    {
        public async Task<List<TerminationItem>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.TerminationItems.OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<List<TerminationItem>> GetAllIncCompAsync(Expression<Func<TerminationItem, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.TerminationItems.Where(filter).OrderByDescending(c => c.Name).ToListAsync();

        }
    }

}
