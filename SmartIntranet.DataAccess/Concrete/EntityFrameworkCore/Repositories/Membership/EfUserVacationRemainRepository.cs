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
    public class EfUserVacationRemainRepository : EfGenericRepository<UserVacationRemain>, IUserVacationRemainDal
    {
        public async Task<List<UserVacationRemain>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.UserVacationRemains.OrderByDescending(c => c.FromDate).ToListAsync();
        }

        public async Task<List<UserVacationRemain>> GetAllIncCompAsync(Expression<Func<UserVacationRemain, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.UserVacationRemains.Where(filter)
                .OrderByDescending(c => c.FromDate).ToListAsync();
        }
    }
}
