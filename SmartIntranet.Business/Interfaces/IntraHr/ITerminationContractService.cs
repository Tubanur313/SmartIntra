using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ITerminationContractService : IGenericService<TerminationContract>
    {
        Task<List<TerminationContract>> GetAllIncCompAsync();
        Task<List<TerminationContract>> GetAllAsync(Expression<Func<TerminationContract, bool>> filter);
        Task<List<TerminationContract>> GetAllIncCompAsync(Expression<Func<TerminationContract, bool>> filter);
    }
}
