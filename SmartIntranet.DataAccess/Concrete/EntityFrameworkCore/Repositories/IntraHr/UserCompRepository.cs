using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraHr
{
    public class UserCompRepository : EfGenericRepository<UserComp>, IUserCompDal
    {
        public async Task<UserComp> FirstOrDefault(int signInUserId)
        {
            await using var context = new IntranetContext();
            return await context.UserComps
           .Where(x => x.UserId == signInUserId && !x.IsDeleted)
           .FirstOrDefaultAsync();
        }

        public async Task<List<UserComp>> GetAllIncAsync(int signInUserId)
        {
            await using var context = new IntranetContext();
            return await context.UserComps
           .Where(x => x.UserId == signInUserId && !x.IsDeleted)
           .Include(x => x.Company)
           .Include(x => x.User)
           .AsNoTracking()
           .ToListAsync();
        }
    }
}
