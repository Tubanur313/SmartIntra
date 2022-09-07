using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IContractTypeDal : IGenericDal<ContractType>
    {
        Task<List<ContractType>> GetAllIncCompAsync(); 
        Task<List<ContractType>> GetAllIncCompAsync(Expression<Func<ContractType, bool>> filter); 
    }
}
