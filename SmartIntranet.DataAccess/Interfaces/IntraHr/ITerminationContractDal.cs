using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface ITerminationContractDal : IGenericDal<TerminationContract>
    {
        Task<List<TerminationContract>> GetAllIncCompAsync(); 
        Task<List<TerminationContract>> GetAllIncCompAsync(Expression<Func<TerminationContract, bool>> filter); 
    }
}
