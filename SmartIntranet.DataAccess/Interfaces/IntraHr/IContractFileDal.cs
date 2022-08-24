using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IContractFileDal : IGenericDal<ContractFile>
    {
        Task<List<ContractFile>> GetAllIncCompAsync(); 
        Task<List<ContractFile>> GetAllIncCompAsync(Expression<Func<ContractFile, bool>> filter); 
    }
}
