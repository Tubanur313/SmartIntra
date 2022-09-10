using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Interfaces.Intranet
{
    public interface INewsDal : IGenericDal<News>
    {
        Task<List<News>> GetAllWithIncludeAsync();
        Task<List<News>> GetAllWithIncludeNonDeleteAsync();
        Task<News> FindByIdIncludeAllAsync(int id);
    }
}
