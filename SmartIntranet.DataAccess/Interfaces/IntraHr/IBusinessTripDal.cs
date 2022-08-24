using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IBusinessTripDal : IGenericDal<BusinessTrip>
    {
        Task<List<BusinessTrip>> GetAllIncAsync(); 
        Task<List<BusinessTrip>> GetAllIncAsync(Expression<Func<BusinessTrip, bool>> filter); 
    }
}
