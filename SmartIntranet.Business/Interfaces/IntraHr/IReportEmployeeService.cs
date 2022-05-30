using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IReportEmployeeService : IGenericService<ReportEmployee>
    {
        Task<List<ReportEmployee>> GetAllIncCompAsync();
        Task<List<ReportEmployee>> GetAllAsync(Expression<Func<ReportEmployee, bool>> filter);
        Task<List<ReportEmployee>> GetAllIncCompAsync(Expression<Func<ReportEmployee, bool>> filter);
    }
}
