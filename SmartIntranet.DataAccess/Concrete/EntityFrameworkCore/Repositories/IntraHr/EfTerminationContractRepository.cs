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
    public class EfTerminationContractRepository : EfGenericRepository<TerminationContract>, ITerminationContractDal
    {
        public async Task<List<TerminationContract>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.TerminationContracts.OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<List<TerminationContract>> GetAllIncCompAsync(Expression<Func<TerminationContract, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.TerminationContracts.Include(x=>x.TerminationItem).Include(x => x.User).ThenInclude(z => z.Position).ThenInclude(z => z.Company).ThenInclude(z => z.Departments).Where(filter)
                .OrderByDescending(c => c.User.Name).ToListAsync();

        }
    }

}
