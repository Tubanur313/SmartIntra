using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ICauseService : IGenericService<Cause>
    {
        Task<List<Cause>> GetAllIncAsync();
        Task<List<Cause>> GetAllAsync(Expression<Func<Cause, bool>> filter);
        Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter);
    }
}
