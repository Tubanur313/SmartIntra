using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IVacancyDal : IGenericDal<Vacancy>
    {
        Task<List<Vacancy>> GetAllIncludeAsync(Expression<Func<Vacancy, bool>> filter);
        Task<Vacancy> FindByIdAllIncludeAsync(int id);
        Vacancy FindByIdIncAsync(int id);
        Task<List<Vacancy>> GetAllWithIncludeAsync();
        Task<List<Vacancy>> ShowAllWithIncludeAsync();
    }
}
