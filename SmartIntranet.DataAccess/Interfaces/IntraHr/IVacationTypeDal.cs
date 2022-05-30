using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IVacationTypeDal : IGenericDal<VacationType>
    {
        Task<List<VacationType>> GetAllIncCompAsync(); 
        Task<List<VacationType>> GetAllIncCompAsync(Expression<Func<VacationType, bool>> filter); 
    }
}
