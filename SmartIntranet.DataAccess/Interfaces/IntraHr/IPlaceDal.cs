using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IPlaceDal : IGenericDal<Place>
    {
        Task<List<Place>> GetAllIncAsync(); 
        Task<List<Place>> GetAllIncAsync(Expression<Func<Place, bool>> filter); 
    }
}
