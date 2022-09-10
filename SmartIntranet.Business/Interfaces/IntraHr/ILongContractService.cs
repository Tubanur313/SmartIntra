using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface ILongContractService : IGenericService<LongContract>
    {
        Task<List<LongContract>> GetAllIncCompAsync();
        Task<List<LongContract>> GetAllAsync(Expression<Func<LongContract, bool>> filter);
        Task<List<LongContract>> GetAllIncCompAsync(Expression<Func<LongContract, bool>> filter);
    }
}
