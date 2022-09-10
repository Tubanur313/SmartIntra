using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IBusinessTripFileDal : IGenericDal<BusinessTripFile>
    {
        Task<List<BusinessTripFile>> GetAllIncAsync(); 
        Task<List<BusinessTripFile>> GetAllIncAsync(Expression<Func<BusinessTripFile, bool>> filter); 
    }
}
