using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IVacationContractService : IGenericService<VacationContract>
    {
        Task<List<VacationContract>> GetAllIncCompAsync();
        Task<List<VacationContract>> GetAllAsync(Expression<Func<VacationContract, bool>> filter);
        Task<List<VacationContract>> GetAllIncCompAsync(Expression<Func<VacationContract, bool>> filter);
    }
}
