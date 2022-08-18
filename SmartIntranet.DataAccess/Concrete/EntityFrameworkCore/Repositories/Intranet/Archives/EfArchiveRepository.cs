using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Intranet.Archives;
using SmartIntranet.Entities.Concrete.Intranet.Archives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet.Archives
{
    public class EfArchiveRepository : EfGenericRepository<Archive>, IArchiveDal
    {
        public async Task<List<Archive>> GetAllIncAsync(int companyId)
        {
            using var context = new IntranetContext();
            return await context.Archives
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.AddedByUser)
                         .ThenInclude(x => x.Company)
                         .ThenInclude(x => x.Departments)
                         .ThenInclude(x => x.Positions)
                .OrderByDescending(c => c.Id)
                .Where(x=>!x.IsDeleted && x.CompanyId == companyId)
                .ToListAsync();
        }
    }
}
