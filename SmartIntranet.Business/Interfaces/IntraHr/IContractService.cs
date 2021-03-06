using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IContractService : IGenericService<Contract>
    {
        Task<List<Contract>> GetAllIncCompAsync();
        Task<List<Contract>> GetAllAsync(Expression<Func<Contract, bool>> filter);
        Task<List<Contract>> GetAllIncCompAsync(Expression<Func<Contract, bool>> filter);
    }
}
