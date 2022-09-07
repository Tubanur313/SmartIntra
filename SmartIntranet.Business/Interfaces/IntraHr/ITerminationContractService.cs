using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface ITerminationContractService : IGenericService<TerminationContract>
    {
        Task<List<TerminationContract>> GetAllIncCompAsync();
        Task<List<TerminationContract>> GetAllAsync(Expression<Func<TerminationContract, bool>> filter);
        Task<List<TerminationContract>> GetAllIncCompAsync(Expression<Func<TerminationContract, bool>> filter);
    }
}
