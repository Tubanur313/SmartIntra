using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where
     TEntity : class, new()
    {
        private IGenericDal<TEntity> _dal;
        public GenericManager(IGenericDal<TEntity> dal)
        {
            _dal = dal;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dal.AddAsync(entity);
        }

        public async Task<TEntity> AddReturnEntityAsync(TEntity entity)
        {
            await _dal.AddReturnEntityAsync(entity);
            return entity;
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _dal.AnyAsync(filter);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _dal.DeleteByIdAsync(id);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dal.FindByIdAsync(id);
        }

       

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dal.GetAllAsync(filter);
        }        

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _dal.GetAllAsync(filter,keySelector);
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _dal.GetAllAsync(keySelector);
        }

       

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dal.GetAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _dal.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _dal.UpdateAsync(entity);
        }

        public async Task UpdateModifiedAsync(TEntity entity)
        {
            await _dal.UpdateModifiedAsync(entity);
        }

        public async Task<TEntity> UpdateReturnEntityAsync(TEntity entity)
        {
            await _dal.UpdateReturnEntityAsync(entity);
            return entity;
        }
    }
}
