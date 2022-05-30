using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IBusinessTripService : IGenericService<BusinessTrip>
    {
        Task<List<BusinessTrip>> GetAllIncAsync();
        Task<List<BusinessTrip>> GetAllAsync(Expression<Func<BusinessTrip, bool>> filter);
        Task<List<BusinessTrip>> GetAllIncAsync(Expression<Func<BusinessTrip, bool>> filter);
    }
}
