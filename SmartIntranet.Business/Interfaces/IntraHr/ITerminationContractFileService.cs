using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ITerminationContractFileService : IGenericService<TerminationContractFile>
    {
        Task<List<TerminationContractFile>> GetAllIncCompAsync();
        Task<List<TerminationContractFile>> GetAllAsync(Expression<Func<TerminationContractFile, bool>> filter);
        Task<List<TerminationContractFile>> GetAllIncCompAsync(Expression<Func<TerminationContractFile, bool>> filter);
    }
}
