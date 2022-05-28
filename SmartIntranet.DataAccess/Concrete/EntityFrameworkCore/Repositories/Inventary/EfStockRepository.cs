using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Inventary
{
    public class EfStockRepository : EfGenericRepository<Stock>, IStockDal
    {
    }
}
