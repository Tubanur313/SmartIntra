using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IContractTypeDal : IGenericDal<ContractType>
    {
        Task<List<ContractType>> GetAllIncCompAsync(); 
        Task<List<ContractType>> GetAllIncCompAsync(Expression<Func<ContractType, bool>> filter); 
    }
}
