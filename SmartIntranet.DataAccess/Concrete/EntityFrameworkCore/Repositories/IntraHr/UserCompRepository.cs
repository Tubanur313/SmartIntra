using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraHr
{
    public class UserCompRepository : EfGenericRepository<UserComp>, IUserCompDal
    {
        public async Task<List<UserComp>> GetAllIncAsync(int signInUserId)
        {
            using var context = new IntranetContext();
            return await context.UserComps
           .Where(x => x.UserId == signInUserId && !x.IsDeleted)
           .Include(x => x.Company).ToListAsync();
        }

        public async Task<List<UserComp>> GetAllIncUserAsync(int signInUserId)
        {
            using var context = new IntranetContext();
            return await context.UserComps
           .Where(x => x.UserId == signInUserId &&
           x.User.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
           .Include(x => x.User)
           .ThenInclude(x => x.Position)
           .ThenInclude(x => x.Company)
           .ThenInclude(x => x.Departments)
           .Include(x => x.User)
           .ThenInclude(x => x.Grade)
           .OrderByDescending(x => x.User.UpdateDate > x.User.CreatedDate ? x.User.UpdateDate : x.User.CreatedDate)
           .ToListAsync();
        }

        public async Task<List<UserComp>> GetAllIncUserWithFilterAsync(int signInUserId, int companyId, int departmentId, int positionId)
        {
            using var context = new IntranetContext();

            if (companyId > 0 && departmentId > 0 && positionId > 0)
            {
                return await context.UserComps
                .Where(x => x.UserId == signInUserId &&
                x.CompanyId == companyId &&
                x.User.DepartmentId == departmentId &&
                x.User.PositionId == positionId &&
                x.User.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.User)
                .ThenInclude(x => x.Position)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .Include(x => x.User)
                .ThenInclude(x => x.Grade)
                .OrderByDescending(x => x.User.UpdateDate > x.User.CreatedDate ? x.User.UpdateDate : x.User.CreatedDate)
                .ToListAsync();
            }
            else if (companyId > 0 && departmentId > 0 && positionId == 0)
            {
                return await context.UserComps
                .Where(x => x.UserId == signInUserId &&
                x.CompanyId == companyId &&
                x.User.DepartmentId == departmentId &&
                x.User.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.User)
                .ThenInclude(x => x.Position)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .Include(x => x.User)
                .ThenInclude(x => x.Grade)
                .OrderByDescending(x => x.User.UpdateDate > x.User.CreatedDate ? x.User.UpdateDate : x.User.CreatedDate)
                .ToListAsync();
            }
            else if (companyId > 0 && departmentId == 0 && positionId > 0)
            {
                return await context.UserComps
                .Where(x => x.UserId == signInUserId &&
                x.CompanyId == companyId &&
                x.User.PositionId == positionId &&
                x.User.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.User)
                .ThenInclude(x => x.Position)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .Include(x => x.User)
                .ThenInclude(x => x.Grade)
                .OrderByDescending(x => x.User.UpdateDate > x.User.CreatedDate ? x.User.UpdateDate : x.User.CreatedDate)
                .ToListAsync();
            }
            else
            {
                return await context.UserComps
                .Where(x => x.UserId == signInUserId &&
                x.User.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)
                .Include(x => x.User)
                .ThenInclude(x => x.Position)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .Include(x => x.User)
                .ThenInclude(x => x.Grade)
                .OrderByDescending(x => x.User.UpdateDate > x.User.CreatedDate ? x.User.UpdateDate : x.User.CreatedDate)
                .ToListAsync();
            }
        }
    }
}
