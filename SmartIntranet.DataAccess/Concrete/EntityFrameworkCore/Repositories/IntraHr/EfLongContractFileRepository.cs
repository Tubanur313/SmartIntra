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
    public class EfLongContractFileRepository : EfGenericRepository<LongContractFile>, ILongContractFileDal
    {
        public async Task<List<LongContractFile>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.LongContractFiles.Include(x => x.Clause).ToListAsync();
        }

        public async Task<List<LongContractFile>> GetAllIncCompAsync(Expression<Func<LongContractFile, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.LongContractFiles.Include(x=>x.Clause).Where(filter).ToListAsync();

        }
    }

}
