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
    }
}
