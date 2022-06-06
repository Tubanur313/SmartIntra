using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces.Inventary
{
    public interface IStockImageDal : IGenericDal<StockImage>
    {
        Task<List<StockImage>> GetAllByStockAsync(int stockId);
    }
}
