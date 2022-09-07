using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface ILongContractFileDal : IGenericDal<LongContractFile>
    {
        Task<List<LongContractFile>> GetAllIncCompAsync(); 
        Task<List<LongContractFile>> GetAllIncCompAsync(Expression<Func<LongContractFile, bool>> filter); 
    }
}
