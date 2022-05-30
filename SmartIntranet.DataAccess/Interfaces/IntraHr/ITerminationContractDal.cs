using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITerminationContractDal : IGenericDal<TerminationContract>
    {
        Task<List<TerminationContract>> GetAllIncCompAsync(); 
        Task<List<TerminationContract>> GetAllIncCompAsync(Expression<Func<TerminationContract, bool>> filter); 
    }
}
