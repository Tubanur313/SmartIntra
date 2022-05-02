using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
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
