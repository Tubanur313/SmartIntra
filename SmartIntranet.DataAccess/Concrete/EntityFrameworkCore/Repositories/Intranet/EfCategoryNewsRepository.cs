using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryNewsRepository : EfGenericRepository<CategoryNews>, ICategoryNewsDal
    {
        public async Task<CategoryNews> FindByIdAllIncAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.CategoryNews.Include(x => x.News).Include(y => y.Category)
                .Where(x => x.Id == id).FirstAsync();
        }

        public CategoryNews FindByIdWithFilter(int newsId, int id)
        {
            using var context = new IntranetContext();
            return context.CategoryNews.Include(x => x.News).Include(y => y.Category)
                .Where(x => x.NewsId == newsId && x.CategoryId == id).FirstOrDefault();
        }

        public async Task<CategoryNews> FindByNewsIdAsync(int ıd)
        {
            using var context = new IntranetContext();
            return await context.CategoryNews.Include(x => x.News).Include(y => y.Category)
                .Where(x => x.NewsId == ıd ).FirstAsync();

        }

        public async Task<List<CategoryNews>> FindByNewsIdcategoryNewsAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.CategoryNews.Include(x => x.News).Include(y => y.Category)
                .Where(x => x.NewsId == id).ToListAsync();
        }

        public async Task<List<CategoryNews>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.CategoryNews.Include(x => x.News).Include(y => y.Category).ToListAsync();

        }

        public async Task<List<CategoryNews>> GetAllWithIncUserCategNewsAsync()
        {
            using var context = new IntranetContext();
            return await context.CategoryNews
                .Include(y => y.Category)
                .Include(x => x.News).ThenInclude(u=>u.AppUser)
                .OrderBy(c => c.Id).ToListAsync();
        }
    }
}
