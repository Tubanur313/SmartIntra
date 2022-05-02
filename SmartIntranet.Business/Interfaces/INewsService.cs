using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface INewsService : IGenericService<News>
    {
        public Task<List<News>> GetAllWithIncludeAsync();
        public Task<List<News>> GetAllWithIncludeNonDeleteAsync();
        Task<News> FindByIdIncludeAllAsync(int id);
    }
}
