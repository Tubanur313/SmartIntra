using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IVacationTypeDal : IGenericDal<VacationType>
    {
        Task<List<VacationType>> GetAllIncCompAsync(); 
        Task<List<VacationType>> GetAllIncCompAsync(Expression<Func<VacationType, bool>> filter); 
    }
}
