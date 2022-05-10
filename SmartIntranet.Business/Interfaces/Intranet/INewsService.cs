using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface INewsService : IGenericService<News>
    {
        public Task<List<News>> GetAllWithIncludeAsync();
        public Task<List<News>> GetAllWithIncludeNonDeleteAsync();
        Task<News> FindByIdIncludeAllAsync(int id);
    }
}
