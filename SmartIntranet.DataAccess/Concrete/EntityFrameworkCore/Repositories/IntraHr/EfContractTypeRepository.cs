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
