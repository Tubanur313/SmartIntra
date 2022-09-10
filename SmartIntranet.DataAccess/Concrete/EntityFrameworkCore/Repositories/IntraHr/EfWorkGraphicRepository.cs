using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraHr
{
    public class EfWorkGraphicRepository : EfGenericRepository<WorkGraphic>, IWorkGraphicDal
    {
        public async Task<List<WorkGraphic>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.WorkGraphics.OrderByDescending(c => c.Name).ToListAsync();
        }

        public async Task<List<WorkGraphic>> GetAllIncCompAsync(Expression<Func<WorkGraphic, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.WorkGraphics.Include(x => x.NonWorkingYear).Where(filter)
                .OrderByDescending(c => c.Name).ToListAsync();

        }
    }

}
