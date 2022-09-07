using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IPlaceService : IGenericService<Place>
    {
        Task<List<Place>> GetAllIncAsync();
        Task<List<Place>> GetAllAsync(Expression<Func<Place, bool>> filter);
        Task<List<Place>> GetAllIncAsync(Expression<Func<Place, bool>> filter,bool asnotrack = false);
    }
}
