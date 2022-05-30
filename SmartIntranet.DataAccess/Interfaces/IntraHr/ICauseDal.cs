using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ICauseDal : IGenericDal<Cause>
    {
        Task<List<Cause>> GetAllIncAsync(); 
        Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter); 
    }
}
