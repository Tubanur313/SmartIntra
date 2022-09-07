using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IBusinessTripDal : IGenericDal<BusinessTrip>
    {
        Task<List<BusinessTrip>> GetAllIncAsync(); 
        Task<List<BusinessTrip>> GetAllIncAsync(Expression<Func<BusinessTrip, bool>> filter); 
    }
}
