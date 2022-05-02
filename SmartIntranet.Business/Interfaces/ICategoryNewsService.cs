using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
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
