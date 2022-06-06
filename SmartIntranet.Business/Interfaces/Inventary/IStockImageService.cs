using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Inventary
{
    public interface IStockImageService : IGenericService<StockImage>
    {
        Task<List<StockImage>> GetAllByStockAsync(int stockId);
    }
}
