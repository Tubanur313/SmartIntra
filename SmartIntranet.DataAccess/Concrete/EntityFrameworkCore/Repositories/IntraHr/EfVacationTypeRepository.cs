using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfVacationTypeRepository : EfGenericRepository<VacationType>, IVacationTypeDal
    {
        public async Task<List<VacationType>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.VacationTypes.OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<List<VacationType>> GetAllIncCompAsync(Expression<Func<VacationType, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.VacationTypes.Where(filter).OrderBy(c => c.Name).ToListAsync();

        }
    }

}
