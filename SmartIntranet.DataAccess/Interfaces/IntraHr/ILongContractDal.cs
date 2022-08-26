using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ILongContractDal : IGenericDal<LongContract>
    {
        Task<List<LongContract>> GetAllIncCompAsync(); 
        Task<List<LongContract>> GetAllIncCompAsync(Expression<Func<LongContract, bool>> filter); 
    }
}
