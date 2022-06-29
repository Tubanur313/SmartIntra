using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Inventary
{
    public class EfStockImageRepository : EfGenericRepository<StockImage>, IStockImageDal
    {
        public async Task<List<StockImage>> GetAllByStockAsync(int stockId)
        {
            using var context = new IntranetContext();
            return await context.StockImages.Where(x => x.StockId == stockId
                && !x.IsDeleted)
                .OrderByDescending(z => z.Id)
                .ToListAsync();
        }
    }
}
