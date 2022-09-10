using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IBusinessTripService : IGenericService<BusinessTrip>
    {
        Task<List<BusinessTrip>> GetAllIncAsync();
        Task<List<BusinessTrip>> GetAllAsync(Expression<Func<BusinessTrip, bool>> filter);
        Task<List<BusinessTrip>> GetAllIncAsync(Expression<Func<BusinessTrip, bool>> filter);
    }
}
