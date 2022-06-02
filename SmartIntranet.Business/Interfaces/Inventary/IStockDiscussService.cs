using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Inventary
{
    public interface IStockDiscussService : IGenericService<StockDiscuss>
    {
        Task<StockDiscuss> GetAllIncludeAsync(int id);
        Task<List<StockDiscuss>> GetAllByTicketAsync(int stockId);
    }
}
