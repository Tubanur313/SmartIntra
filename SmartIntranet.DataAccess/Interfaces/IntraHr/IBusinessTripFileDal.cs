using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IBusinessTripFileDal : IGenericDal<BusinessTripFile>
    {
        Task<List<BusinessTripFile>> GetAllIncAsync(); 
        Task<List<BusinessTripFile>> GetAllIncAsync(Expression<Func<BusinessTripFile, bool>> filter); 
    }
}
