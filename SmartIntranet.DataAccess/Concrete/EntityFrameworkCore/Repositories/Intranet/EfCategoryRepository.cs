using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
    }
}
