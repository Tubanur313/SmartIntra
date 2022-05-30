using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IPersonalContractService : IGenericService<PersonalContract>
    {
        Task<List<PersonalContract>> GetAllIncCompAsync();
        Task<List<PersonalContract>> GetAllAsync(Expression<Func<PersonalContract, bool>> filter);
        Task<List<PersonalContract>> GetAllIncCompAsync(Expression<Func<PersonalContract, bool>> filter);
    }
}
