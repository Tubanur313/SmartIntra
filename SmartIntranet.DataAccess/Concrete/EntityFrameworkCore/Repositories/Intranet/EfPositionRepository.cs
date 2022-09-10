using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Intranet;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet
{
    public class EfPositionRepository : EfGenericRepository<Position>, IPositionDal
    {
        public async Task<List<Position>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Positions
                .Where(z => !z.IsDeleted)
                .Include(z => z.Company)
                .Include(z => z.Department)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
