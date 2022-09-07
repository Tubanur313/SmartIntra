using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IVacationContractDal : IGenericDal<VacationContract>
    {
        Task<List<VacationContract>> GetAllIncCompAsync(); 
        Task<List<VacationContract>> GetAllIncCompAsync(Expression<Func<VacationContract, bool>> filter); 
    }
}
