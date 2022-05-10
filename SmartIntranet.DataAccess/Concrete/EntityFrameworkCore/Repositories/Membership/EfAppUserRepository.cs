using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<IntranetUser>, IAppUserDal
    {
        public async Task<IntranetUser> FindByUserAllInc(int id)
        {
            using var context = new IntranetContext();
            return await context.Users
                .Where(x => x.Id == id)
                .Include(x => x.Company)
                .Include(y => y.Department)
                .Include(z => z.Position).FirstAsync();

        }

        public async Task<IntranetUser> FindUserByEmail(string email)
        {
            using var context = new IntranetContext();
            return await context.Users
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Users
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Company)
                .Include(y => y.Department)
                .Include(z => z.Position)
                .ToListAsync();

        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Users.Where(filter).Include(x => x.Company).Include(y => y.Department).Include(z => z.Position).Where(filter).ToListAsync();

        }

        public async Task<bool> IsExistEmail(string email)
        {
            using var context = new IntranetContext();
            return await context.Users.AnyAsync(x => x.Email == email);
        }

    }
}
