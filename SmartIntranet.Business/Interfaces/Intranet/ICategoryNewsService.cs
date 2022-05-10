using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface ICategoryNewsService : IGenericService<CategoryNews>
    {

        public Task<CategoryNews> FindByNewsIdAsync(int id);
        public Task<List<CategoryNews>> FindByNewsIdcategoryNewsAsync(int id);
        public Task<List<CategoryNews>> GetAllIncludeAsync();
        public Task<List<CategoryNews>> GetAllWithIncUserCategNewsAsync();
        public Task<CategoryNews> FindByIdAllIncAsync(int id);
        public CategoryNews FindByIdWithFilter(int newsId, int id);
    }
}
