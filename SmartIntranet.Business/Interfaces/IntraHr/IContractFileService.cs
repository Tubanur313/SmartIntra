using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IContractFileService : IGenericService<ContractFile>
    {
        Task<List<ContractFile>> GetAllIncCompAsync();
        Task<List<ContractFile>> GetAllAsync(Expression<Func<ContractFile, bool>> filter);
        Task<List<ContractFile>> GetAllIncCompAsync(Expression<Func<ContractFile, bool>> filter);
    }
}
