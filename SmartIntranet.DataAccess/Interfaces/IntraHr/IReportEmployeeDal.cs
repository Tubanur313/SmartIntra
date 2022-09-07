using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IReportEmployeeDal : IGenericDal<ReportEmployee>
    {
        Task<List<ReportEmployee>> GetAllIncCompAsync(); 
        Task<List<ReportEmployee>> GetAllIncCompAsync(Expression<Func<ReportEmployee, bool>> filter); 
    }
}
