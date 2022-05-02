using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Concrete
{
    public class CategoryNewsManager : GenericManager<CategoryNews>, ICategoryNewsService
    {
        private readonly IGenericDal<CategoryNews> _genericDal;
        private readonly ICategoryNewsDal _categoryNewsDal;
 
        public CategoryNewsManager(IGenericDal<CategoryNews> genericDal, ICategoryNewsDal categoryNewsDal):base(genericDal)
        {
            _categoryNewsDal = categoryNewsDal;
            _genericDal = genericDal;
        }

        public async Task<CategoryNews> FindByIdAllIncAsync(int id)
        {
            return await _categoryNewsDal.FindByIdAllIncAsync(id);
        }

        public CategoryNews FindByIdWithFilter(int newsId, int id)
        {
            return _categoryNewsDal.FindByIdWithFilter(newsId,id);
        }

        public async Task<CategoryNews> FindByNewsIdAsync(int Id)
        {
           return await _categoryNewsDal.FindByNewsIdAsync(Id);
        }

        public async Task<List<CategoryNews>> FindByNewsIdcategoryNewsAsync(int ıd)
        {
            return await _categoryNewsDal.FindByNewsIdcategoryNewsAsync(ıd);
        }

        public async Task<List<CategoryNews>> GetAllIncludeAsync()
        {
            return await _categoryNewsDal.GetAllIncludeAsync();
        }

        public async Task<List<CategoryNews>> GetAllWithIncUserCategNewsAsync()
        {
            return await _categoryNewsDal.GetAllWithIncUserCategNewsAsync();
        }
    }
}
