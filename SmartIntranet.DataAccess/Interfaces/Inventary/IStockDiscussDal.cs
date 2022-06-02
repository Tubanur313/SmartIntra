using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces.Inventary
{
    public interface IStockDiscussDal : IGenericDal<StockDiscuss>
    {
        Task<StockDiscuss> GetAllIncludeAsync(int id);
        Task<List<StockDiscuss>> GetAllByTicketAsync(int ticketId);
    }
}
