using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ILongContractService : IGenericService<LongContract>
    {
        Task<List<LongContract>> GetAllIncCompAsync();
        Task<List<LongContract>> GetAllAsync(Expression<Func<LongContract, bool>> filter);
        Task<List<LongContract>> GetAllIncCompAsync(Expression<Func<LongContract, bool>> filter);
    }
}
