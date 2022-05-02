using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface INewsDal : IGenericDal<News>
    {
        Task<List<News>> GetAllWithIncludeAsync();
        Task<List<News>> GetAllWithIncludeNonDeleteAsync();
        Task<News> FindByIdIncludeAllAsync(int id);
    }
}
