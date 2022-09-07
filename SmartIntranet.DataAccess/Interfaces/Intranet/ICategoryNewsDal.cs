using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Interfaces.Intranet
{
    public interface ICategoryNewsDal : IGenericDal<CategoryNews>
    {
        Task<CategoryNews> FindByNewsIdAsync(int id);
        Task<List<CategoryNews>> FindByNewsIdcategoryNewsAsync(int id);
        Task<List<CategoryNews>> GetAllIncludeAsync();
        Task<List<CategoryNews>> GetAllWithIncUserCategNewsAsync();
        Task<CategoryNews> FindByIdAllIncAsync(int id);
        CategoryNews FindByIdWithFilter(int newsId, int id);
    }
}
