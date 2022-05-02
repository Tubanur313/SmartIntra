
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryTicketRepository : EfGenericRepository<CategoryTicket>, ICategoryTicketDal
    {
        public async Task<List<CategoryTicket>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.CategoryTickets
                .Where(z => z.IsDeleted == false)
                .Include(z => z.Supporter)
                .ToListAsync();
        }

        public async Task<CategoryTicket> GetIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.CategoryTickets
                .Include(z => z.Supporter)
                .Where(z => z.IsDeleted == false && z.Id==id).FirstOrDefaultAsync();
        }
    }
}
