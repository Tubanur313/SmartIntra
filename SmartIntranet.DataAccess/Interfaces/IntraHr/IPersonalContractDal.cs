using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IPersonalContractDal : IGenericDal<PersonalContract>
    {
        Task<List<PersonalContract>> GetAllIncCompAsync(); 
        Task<List<PersonalContract>> GetAllIncCompAsync(Expression<Func<PersonalContract, bool>> filter); 
    }
}
