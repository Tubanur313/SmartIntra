using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Membership;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Membership
{
    public class EfUserContractRepository : EfGenericRepository<UserContractFile>, IUserContractFileDal
    {
        public async Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int id)
        {
           await using var context = new IntranetContext();
            return await context.UserContractFiles
                .Where(i=>i.AppUserId==id && !i.IsDeleted)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

    }
}
