using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IPersonalContractDal : IGenericDal<PersonalContract>
    {
        Task<List<PersonalContract>> GetAllIncCompAsync(); 
        Task<List<PersonalContract>> GetAllIncCompAsync(Expression<Func<PersonalContract, bool>> filter); 
    }
}
