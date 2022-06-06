using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ILongContractFileDal : IGenericDal<LongContractFile>
    {
        Task<List<LongContractFile>> GetAllIncCompAsync(); 
        Task<List<LongContractFile>> GetAllIncCompAsync(Expression<Func<LongContractFile, bool>> filter); 
    }
}
