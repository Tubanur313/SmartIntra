using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IContractTypeService : IGenericService<ContractType>
    {
        Task<List<ContractType>> GetAllIncCompAsync();
        Task<List<ContractType>> GetAllAsync(Expression<Func<ContractType, bool>> filter);
        Task<List<ContractType>> GetAllIncCompAsync(Expression<Func<ContractType, bool>> filter);
    }
}
