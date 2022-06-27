using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<IntranetUser>, IAppUserDal
    {
        public async Task<IntranetUser> FindByUserAllInc(int id)
        {
            using var context = new IntranetContext();
            return await context.Users.Include(x => x.Company).Include(y => y.Department)
            .Include(y => y.UserContractFiles)
            .Include(y => y.UserExperiences)
            .Include(y => y.UserVacationRemains)
            .Include(z => z.Position)
            .Include(z => z.Grade)
            .Where(x => x.Id == id)
            .OrderByDescending(x => x.Id)
            .FirstAsync();

        }

        public async Task<IntranetUser> FindUserPosWithId(int id)
        {
            using var context = new IntranetContext();
            return await context.Users.AsNoTracking()
                .Include(z => z.Position)
                .Where(u => u.Id == id)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IntranetUser> FindUserByEmail(string email)
        {
            using var context = new IntranetContext();
            return await context.Users
                .Where(u => u.Email == email)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Users.Include(z => z.Position)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments).Include(z => z.Grade)
                .OrderByDescending(c => c.Name)
                .ToListAsync();


        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Users
                .Include(z => z.Position).ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments).Include(z => z.Grade)
                .Where(filter)
                .OrderByDescending(c => c.Name)
                .ToListAsync();


        }

        public async Task<bool> IsExistEmail(string email)
        {
            using var context = new IntranetContext();
            return await context.Users
                .AnyAsync(x => x.Email == email);
        }

    }
}
