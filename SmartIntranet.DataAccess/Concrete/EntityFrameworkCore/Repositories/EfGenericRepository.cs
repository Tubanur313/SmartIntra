using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {

        public async Task AddAsync(TEntity entity)
        {
            await using var context = new IntranetContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> AddReturnEntityAsync(TEntity entity)
        {
            await using var context = new IntranetContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await using var context = new IntranetContext();
            context.Remove(await context.FindAsync<TEntity>(id));
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            await using var context = new IntranetContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            await using var context = new IntranetContext();
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new IntranetContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            await using var context = new IntranetContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            await using var context = new IntranetContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new IntranetContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await using var context = new IntranetContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await using var context = new IntranetContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateModifiedAsync(TEntity entity)
        {
            await using var context = new IntranetContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateReturnEntityAsync(TEntity entity)
        {
            await using var context = new IntranetContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new IntranetContext();
            return await context.Set<TEntity>().AnyAsync(filter);
        }
        
    }
}
