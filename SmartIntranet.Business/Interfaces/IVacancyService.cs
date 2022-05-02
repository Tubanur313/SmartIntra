using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IVacancyService : IGenericService<Vacancy>
    {
        Task<List<Vacancy>> GetAllIncludeAsync(Expression<Func<Vacancy, bool>> filter);
        Task<Vacancy> FindByIdAllIncludeAsync(int id);
        Vacancy FindByIdIncAsync(int id);
    }
}
