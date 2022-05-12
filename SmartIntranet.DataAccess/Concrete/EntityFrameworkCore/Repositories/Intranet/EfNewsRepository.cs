using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNewsRepository : EfGenericRepository<News>, INewsDal
    {
        public async Task<News> FindByIdIncludeAllAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.News               
                .Include(nf => nf.NewsFiles)
                .Include(nf => nf.AppUser)
                .Include(nf => nf.CategoryNews)
                .ThenInclude(nf => nf.Category)
                .Where(nf => !nf.IsDeleted && nf.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<News>> GetAllWithIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.News
                .Include(nf=>nf.NewsFiles)
                .Include(nf => nf.AppUser)
                .Include(nf => nf.CategoryNews)
                .Where(nf => !nf.IsDeleted)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<News>> GetAllWithIncludeNonDeleteAsync()
        {
            using var context = new IntranetContext();
            return await context.News
                .Include(nf => nf.NewsFiles)
                .Include(nf => nf.AppUser)
                .Include(nf => nf.CategoryNews)
                .Where(nf => nf.DeleteByUserId==null && !nf.IsDeleted)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }
    }
}
