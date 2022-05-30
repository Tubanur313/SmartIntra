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
    public class EfVacationContractFileRepository : EfGenericRepository<VacationContractFile>, IVacationContractFileDal
    {
        public async Task<List<VacationContractFile>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.VacationContractFiles.Include(x => x.Clause).ToListAsync();
        }

        public async Task<List<VacationContractFile>> GetAllIncCompAsync(Expression<Func<VacationContractFile, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.VacationContractFiles.Include(x=>x.Clause).Where(filter).ToListAsync();

        }
    }

}
