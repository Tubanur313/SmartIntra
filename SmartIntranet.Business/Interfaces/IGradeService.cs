using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IGradeService : IGenericService<Grade>
    {
        Task<List<Grade>> GetAllAsync(Expression<Func<Grade, bool>> filter);
    }
}
