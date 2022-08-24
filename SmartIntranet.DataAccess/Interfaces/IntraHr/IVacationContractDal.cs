using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IVacationContractDal : IGenericDal<VacationContract>
    {
        Task<List<VacationContract>> GetAllIncCompAsync(); 
        Task<List<VacationContract>> GetAllIncCompAsync(Expression<Func<VacationContract, bool>> filter); 
    }
}
