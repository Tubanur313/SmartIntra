using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IPlaceDal : IGenericDal<Place>
    {
        Task<List<Place>> GetAllIncAsync(); 
        Task<List<Place>> GetAllIncAsync(Expression<Func<Place, bool>> filter, bool asnotrack = false); 
    }
}
