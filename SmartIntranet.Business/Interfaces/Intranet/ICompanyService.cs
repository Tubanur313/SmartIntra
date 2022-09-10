using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<List<Company>> GetAllAsync(Expression<Func<Company, bool>> filter);
        
    }
}
