using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IVacationTypeService : IGenericService<VacationType>
    {
        Task<List<VacationType>> GetAllIncCompAsync();
        Task<List<VacationType>> GetAllAsync(Expression<Func<VacationType, bool>> filter);
        Task<List<VacationType>> GetAllIncCompAsync(Expression<Func<VacationType, bool>> filter);
    }
}
