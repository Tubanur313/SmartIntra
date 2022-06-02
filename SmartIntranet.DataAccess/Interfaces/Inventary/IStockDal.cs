using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces.Inventary
{
    public interface IStockDal : IGenericDal<Stock>
    {
        Task<List<Stock>> GetStockAllIncludeAsync();
        Task<Stock> FindByIdIncludeAsync(int id);
    }
}
