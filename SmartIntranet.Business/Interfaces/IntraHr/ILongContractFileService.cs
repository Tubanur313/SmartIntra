using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ILongContractFileService : IGenericService<LongContractFile>
    {
        Task<List<LongContractFile>> GetAllIncCompAsync();
        Task<List<LongContractFile>> GetAllAsync(Expression<Func<LongContractFile, bool>> filter);
        Task<List<LongContractFile>> GetAllIncCompAsync(Expression<Func<LongContractFile, bool>> filter);
    }
}
