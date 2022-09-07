using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface ILongContractDal : IGenericDal<LongContract>
    {
        Task<List<LongContract>> GetAllIncCompAsync(); 
        Task<List<LongContract>> GetAllIncCompAsync(Expression<Func<LongContract, bool>> filter); 
    }
}
