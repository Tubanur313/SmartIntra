using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket
{
    public class EfCategoryTicketRepository : EfGenericRepository<CategoryTicket>, ICategoryTicketDal
    {
        public async Task<List<CategoryTicket>> GetAllIncludeAsync(bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)

                return await context.CategoryTickets
                    .Where(z => !z.IsDeleted)
                    .Include(z => z.Supporter)
                    .AsNoTracking()
                    .ToListAsync();
            return await context.CategoryTickets
                .Where(z => !z.IsDeleted)
                .Include(z => z.Supporter)
                .ToListAsync();
        }

        public async Task<CategoryTicket> GetIncludeAsync(int id)
        {
            await using var context = new IntranetContext();
            return await context.CategoryTickets
                .Include(z => z.Supporter)
                .Where(z => !z.IsDeleted && z.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
