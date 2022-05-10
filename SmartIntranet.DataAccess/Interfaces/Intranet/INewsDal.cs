using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface INewsDal : IGenericDal<News>
    {
        Task<List<News>> GetAllWithIncludeAsync();
        Task<List<News>> GetAllWithIncludeNonDeleteAsync();
        Task<News> FindByIdIncludeAllAsync(int id);
    }
}
