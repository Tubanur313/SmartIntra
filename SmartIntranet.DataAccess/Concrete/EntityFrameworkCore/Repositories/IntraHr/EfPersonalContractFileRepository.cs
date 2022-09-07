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
    public class EfPersonalContractFileRepository : EfGenericRepository<PersonalContractFile>, IPersonalContractFileDal
    {
        public async Task<List<PersonalContractFile>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.PersonalContractFiles.Include(x => x.Clause).ToListAsync();
        }

        public async Task<List<PersonalContractFile>> GetAllIncCompAsync(Expression<Func<PersonalContractFile, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.PersonalContractFiles.Include(x=>x.Clause).Where(filter).ToListAsync();

        }
    }

}
