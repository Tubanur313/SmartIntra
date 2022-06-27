using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Inventary
{
    public class EfStockDiscussRepository : EfGenericRepository<StockDiscuss>, IStockDiscussDal
    {
        public async Task<List<StockDiscuss>> GetAllByTicketAsync(int stockId)
        {
            using var context = new IntranetContext();
            return await context.StockDiscusses
                .Where(x => x.StockId == stockId)
                .OrderBy(x => x.Id)
                .Include(x => x.IntranetUser)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .OrderByDescending(z => z.Id)
                .ToListAsync();
        }

        public async Task<StockDiscuss> GetAllIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.StockDiscusses
                .OrderBy(x => x.Id)
                .Include(x => x.IntranetUser)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .OrderByDescending(z => z.Id)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
