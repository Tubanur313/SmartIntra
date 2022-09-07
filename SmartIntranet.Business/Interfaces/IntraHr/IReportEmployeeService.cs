using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IReportEmployeeService : IGenericService<ReportEmployee>
    {
        Task<List<ReportEmployee>> GetAllIncCompAsync();
        Task<List<ReportEmployee>> GetAllAsync(Expression<Func<ReportEmployee, bool>> filter);
        Task<List<ReportEmployee>> GetAllIncCompAsync(Expression<Func<ReportEmployee, bool>> filter);
    }
}
