using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Inventary
{
    public interface IStockService : IGenericService<Stock>
    {
        Task<List<Stock>> GetStockAllIncludeAsync();
    }
}
