using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class,new()
    {

       
        Task<List<TEntity>> GetAllAsync(bool asnotrack = false);
        Task<List<TEntity>> GetAllAsync(Expression < Func<TEntity, bool>> filter, bool asnotrack = false);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector, bool asnotrack = false);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector, bool asnotrack = false);
        Task<TEntity> FindByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task AddAsync(TEntity entity);
        Task<TEntity> AddReturnEntityAsync(TEntity entity);
        Task<TEntity> UpdateReturnEntityAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task UpdateModifiedAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}
