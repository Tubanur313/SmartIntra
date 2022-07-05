using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Inventary
{
    public interface IStockService : IGenericService<Stock>
    {
        Task<List<Stock>> GetStockAllIncludeAsync();
        Task<Stock> FindByIdIncludeAsync(int id);
        Task<List<Stock>> FilterByStatusCategCompAsync(int stockCategoryId, int companyId, StockStatus StockStatus);
    }
}
