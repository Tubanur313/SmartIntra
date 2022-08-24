using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IVacationContractService : IGenericService<VacationContract>
    {
        Task<List<VacationContract>> GetAllIncCompAsync();
        Task<List<VacationContract>> GetAllAsync(Expression<Func<VacationContract, bool>> filter);
        Task<List<VacationContract>> GetAllIncCompAsync(Expression<Func<VacationContract, bool>> filter);
    }
}
