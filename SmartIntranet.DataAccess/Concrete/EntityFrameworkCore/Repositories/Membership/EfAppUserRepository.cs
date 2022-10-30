using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Membership;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Membership
{
    public class EfAppUserRepository : EfGenericRepository<IntranetUser>, IAppUserDal
    {
        public async Task<IntranetUser> FindByUserAllInc(int id)
        {
            await using var context = new IntranetContext();
            return await context.Users
            .Include(x => x.Company)
            .Include(y => y.Department)
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
            await using var context = new IntranetContext();
            return await context.Users.AsNoTracking()
                .Include(z => z.Position)
                .Where(u => u.Id == id)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IntranetUser> FindUserByEmail(string email)
        {
            await using var context = new IntranetContext();
            return await context.Users
                .Where(u => u.Email == email)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> IsExistEmail(string email)
        {
            await using var context = new IntranetContext();
            return await context.Users
                .AnyAsync(x => x.Email == email);
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)
                return await context.Users.Include(z => z.Position)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments).Include(z => z.Grade)
                    .OrderByDescending(c => c.Name)
                    .AsNoTracking()
                    .ToListAsync();
            return await context.Users.Include(z => z.Position)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments).Include(z => z.Grade)
                .OrderByDescending(c => c.Name)
                .ToListAsync();


        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter, bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)

                return await context.Users
                .Include(z => z.Position).ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments).Include(z => z.Grade)
                .Where(filter)
                .OrderByDescending(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
            return await context.Users
                .Include(z => z.Position).ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments).Include(z => z.Grade)
                .Where(filter)
                .OrderByDescending(c => c.Name)
                .ToListAsync();


        }

        public async Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int compId, int departId, int positId, bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (asnotrack)

                if (compId > 0 && departId > 0 && positId > 0)
                {
                    return await context.Users
                    .Where(x =>
                    x.CompanyId == compId &&
                    x.DepartmentId == departId &&
                    x.PositionId == positId &&
                    x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                    .Include(x => x.Position)
                    .Include(x => x.Company)
                    .Include(x => x.Department)
                    .Include(x => x.Grade)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .AsNoTracking()
                    .ToListAsync();
                }
                else if (compId > 0 && departId > 0 && positId == 0)
                {
                    return await context.Users
                    .Where(x =>
                    x.CompanyId == compId &&
                    x.DepartmentId == departId &&
                    x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                    .Include(x => x.Position)
                    .Include(x => x.Company)
                    .Include(x => x.Department)
                    .Include(x => x.Grade)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .AsNoTracking().ToListAsync();
                }
                else if (compId > 0 && departId == 0 && positId == 0)
                {
                    return await context.Users
                    .Where(x =>
                    x.CompanyId == compId &&
                    x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                    .Include(x => x.Position)
                    .Include(x => x.Company)
                    .Include(x => x.Department)
                    .Include(x => x.Grade)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .AsNoTracking().ToListAsync();
                }
                else
                {
                    return await context.Users
                    .Where(x =>
                    x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                    .Include(x => x.Position)
                    .Include(x => x.Company)
                    .Include(x => x.Department)
                    .Include(x => x.Grade)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .AsNoTracking().ToListAsync();
                }
            if (compId > 0 && departId > 0 && positId > 0)
            {
                return await context.Users
                .Where(x =>
                x.CompanyId == compId &&
                x.DepartmentId == departId &&
                x.PositionId == positId &&
                x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.Position)
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.Grade)
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToListAsync();
            }
            else if (compId > 0 && departId > 0 && positId == 0)
            {
                return await context.Users
                .Where(x =>
                x.CompanyId == compId &&
                x.DepartmentId == departId &&
                x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.Position)
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.Grade)
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToListAsync();
            }
            else if (compId > 0 && departId == 0 && positId == 0)
            {
                return await context.Users
                .Where(x =>
                x.CompanyId == compId &&
                x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.Position)
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.Grade)
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToListAsync();
            }
            else
            {
                return await context.Users
                .Where(x =>
                x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.Position)
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.Grade)
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToListAsync();
            }
        }

        public async Task<List<IntranetUser>> GetAllIncUserAsync(int? userCompId, bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (userCompId is null)
            {
                return new List<IntranetUser>();
            }

            if (asnotrack)
                return await context.Users
                    .Where(x =>
                        x.Email != "tahiroglumahir@gmail.com"
                        && x.CompanyId == userCompId && !x.IsDeleted)
                    .Include(x => x.Position)
                    .Include(x => x.Company)
                    .Include(x => x.Department)
                    .Include(x => x.Grade)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .AsNoTracking()
                    .ToListAsync();
            return await context.Users
                .Where(x =>
                    x.Email != "tahiroglumahir@gmail.com"
                    && x.CompanyId == userCompId && !x.IsDeleted)
                .Include(x => x.Position)
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.Grade)
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToListAsync();

        }

        public async Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int? userCompId, bool asnotrack = false)
        {
            await using var context = new IntranetContext();
            if (userCompId is null)
            {
                return new List<IntranetUser>();
            }

            if (asnotrack)
                return await context.Users
                    .Where(x =>
                        x.Email != "tahiroglumahir@gmail.com"
                        && x.CompanyId == userCompId && !x.IsDeleted)
                    .Include(x => x.Position)
                    .Include(x => x.Company)
                    .Include(x => x.Department)
                    .Include(x => x.Grade)
                    .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                    .AsNoTracking().ToListAsync();
            return await context.Users
                .Where(x =>
                    x.Email != "tahiroglumahir@gmail.com"
                    && x.CompanyId == userCompId && !x.IsDeleted)
                .Include(x => x.Position)
                .Include(x => x.Company)
                .Include(x => x.Department)
                .Include(x => x.Grade)
                .OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate)
                .ToListAsync();
        }

    }
}
