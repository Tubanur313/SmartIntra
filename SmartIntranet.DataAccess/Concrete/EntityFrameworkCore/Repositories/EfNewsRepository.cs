using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
                //.Where(nf => nf.IsActive)
                .Where(nf => nf.Id == id)
                .FirstAsync();
        }

        public async Task<List<News>> GetAllWithIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.News
                .Include(nf=>nf.NewsFiles)
                .Include(nf => nf.AppUser)
                .Include(nf => nf.CategoryNews)
                //.Where(nf => nf.IsActive)
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
                .Where(nf => nf.DeleteByUserId==null && nf.IsDeleted!=true)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }
    }
}
