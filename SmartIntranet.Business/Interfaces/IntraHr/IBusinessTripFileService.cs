using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IBusinessTripFileService : IGenericService<BusinessTripFile>
    {
        Task<List<BusinessTripFile>> GetAllIncAsync();
        Task<List<BusinessTripFile>> GetAllAsync(Expression<Func<BusinessTripFile, bool>> filter);
        Task<List<BusinessTripFile>> GetAllIncAsync(Expression<Func<BusinessTripFile, bool>> filter);
    }
}
