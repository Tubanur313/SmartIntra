using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface IVacancyService : IGenericService<Vacancy>
    {
        Task<Vacancy> FindByIdAllIncludeAsync(int id);
        Vacancy FindByIdIncAsync(int id);
        Task<List<Vacancy>> GetAllWithIncludeAsync();
        Task<List<Vacancy>> ShowAllWithIncludeAsync();
    }
}
