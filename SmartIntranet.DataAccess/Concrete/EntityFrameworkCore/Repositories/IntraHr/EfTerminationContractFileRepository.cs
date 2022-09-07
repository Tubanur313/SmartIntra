using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraHr
{
    public class EfTerminationContractFileRepository : EfGenericRepository<TerminationContractFile>, ITerminationContractFileDal
    {
        public async Task<List<TerminationContractFile>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.TerminationContractFiles.Include(x => x.Clause).ToListAsync();
        }

        public async Task<List<TerminationContractFile>> GetAllIncCompAsync(Expression<Func<TerminationContractFile, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.TerminationContractFiles.Include(x=>x.Clause).Where(filter).ToListAsync();

        }
    }

}
