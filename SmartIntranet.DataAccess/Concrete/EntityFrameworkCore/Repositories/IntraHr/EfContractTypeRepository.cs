using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContractTypeRepository : EfGenericRepository<ContractType>, IContractTypeDal
    {
        public async Task<List<ContractType>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.ContractTypes.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<List<ContractType>> GetAllIncCompAsync(Expression<Func<ContractType, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.ContractTypes.Where(filter)
                .OrderBy(c => c.Name).ToListAsync();

        }
    }

}
