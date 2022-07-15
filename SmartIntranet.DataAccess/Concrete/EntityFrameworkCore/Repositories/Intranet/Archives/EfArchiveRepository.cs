using SmartIntranet.DataAccess.Interfaces.Intranet.Archives;
using SmartIntranet.Entities.Concrete.Intranet.Archives;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet.Archives
{
    public class EfArchiveRepository : EfGenericRepository<Archive>, IArchiveDal
    {
    }
}
