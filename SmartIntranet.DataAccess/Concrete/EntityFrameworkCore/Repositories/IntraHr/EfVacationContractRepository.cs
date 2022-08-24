using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfVacationContractRepository : EfGenericRepository<VacationContract>, IVacationContractDal
    {
        public async Task<List<VacationContract>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.VacationContracts.OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<List<VacationContract>> GetAllIncCompAsync(Expression<Func<VacationContract, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.VacationContracts.Include(x=>x.VacationType).Include(x => x.User).ThenInclude(z => z.Position).ThenInclude(z => z.Company).ThenInclude(z => z.Departments).Where(filter)
                .OrderByDescending(c => c.User.Name).ToListAsync();

        }
    }

}
