using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<List<Company>> GetAllAsync(Expression<Func<Company, bool>> filter);
        
    }
}
