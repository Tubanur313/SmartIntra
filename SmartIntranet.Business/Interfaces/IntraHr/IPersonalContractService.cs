using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IPersonalContractService : IGenericService<PersonalContract>
    {
        Task<List<PersonalContract>> GetAllIncCompAsync();
        Task<List<PersonalContract>> GetAllAsync(Expression<Func<PersonalContract, bool>> filter);
        Task<List<PersonalContract>> GetAllIncCompAsync(Expression<Func<PersonalContract, bool>> filter);
    }
}
