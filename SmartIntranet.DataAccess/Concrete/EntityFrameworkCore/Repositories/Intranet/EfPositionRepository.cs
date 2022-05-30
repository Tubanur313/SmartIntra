using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPositionRepository : EfGenericRepository<Position>, IPositionDal
    {
        public async Task<List<Position>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Positions
                .Where(z => z.IsDeleted == false)
                .Include(z => z.Company)
                .Include(z => z.Department)
                .ToListAsync();
        }
    }
}
