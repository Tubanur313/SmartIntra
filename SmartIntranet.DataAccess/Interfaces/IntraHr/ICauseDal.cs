using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface ICauseDal : IGenericDal<Cause>
    {
        Task<List<Cause>> GetAllIncAsync(bool asnotrack = false); 
        Task<List<Cause>> GetAllIncAsync(Expression<Func<Cause, bool>> filter, bool asnotrack = false); 
    }
}
