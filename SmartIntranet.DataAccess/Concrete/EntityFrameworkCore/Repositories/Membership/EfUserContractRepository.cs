using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
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
    public class EfUserContractRepository : EfGenericRepository<UserContractFile>, IUserContractFileDal
    {
        public async Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int Id)
        {
            using var context = new IntranetContext();
            return await context.UserContractFiles
                .Where(i=>i.AppUserId==Id && !i.IsDeleted)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

    }
}
