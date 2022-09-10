using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IContractFileDal : IGenericDal<ContractFile>
    {
        Task<List<ContractFile>> GetAllIncCompAsync(); 
        Task<List<ContractFile>> GetAllIncCompAsync(Expression<Func<ContractFile, bool>> filter); 
    }
}
