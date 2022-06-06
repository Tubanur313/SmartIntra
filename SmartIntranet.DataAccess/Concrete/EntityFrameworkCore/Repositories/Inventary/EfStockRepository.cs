using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Inventary
{
    public class EfStockRepository : EfGenericRepository<Stock>, IStockDal
    {
        public async Task<Stock> FindByIdIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Stocks.Where(x => !x.IsDeleted && x.Id ==id)
                .Include(x => x.Company)
                .Include(x => x.IntranetUser)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .ThenInclude(x => x.Positions)
                .Include(x => x.StockCategory)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Stock>> GetStockAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Stocks.Where(x => !x.IsDeleted)
                .Include(x => x.Company)
                .Include(x => x.IntranetUser)
                .ThenInclude(x=>x.Company)
                .ThenInclude(x=>x.Departments)
                .ThenInclude(x=>x.Positions)
                .Include(x => x.StockCategory)
                .ToListAsync();
        }
    }
}
