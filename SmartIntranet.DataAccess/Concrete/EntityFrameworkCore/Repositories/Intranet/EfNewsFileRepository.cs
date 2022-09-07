using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Intranet;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet
{
    public class EfNewsFileRepository : EfGenericRepository<NewsFile>, INewsFileDal
    {

        async Task<List<NewsFile>> INewsFileDal.GetAllByUserIdAsync(int newsId)
        {
            using var context = new IntranetContext();
            return await context.NewsFiles
                .Where(u => u.NewsId == newsId && !u.IsDeleted)
                .OrderByDescending(c => c.Name)
                .ToListAsync();
        }
    }

}
