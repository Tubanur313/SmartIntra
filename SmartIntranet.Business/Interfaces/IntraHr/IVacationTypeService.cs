using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IVacationTypeService : IGenericService<VacationType>
    {
        Task<List<VacationType>> GetAllIncCompAsync();
        Task<List<VacationType>> GetAllAsync(Expression<Func<VacationType, bool>> filter);
        Task<List<VacationType>> GetAllIncCompAsync(Expression<Func<VacationType, bool>> filter);
    }
}
