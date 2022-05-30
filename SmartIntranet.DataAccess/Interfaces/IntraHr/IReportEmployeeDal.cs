using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IReportEmployeeDal : IGenericDal<ReportEmployee>
    {
        Task<List<ReportEmployee>> GetAllIncCompAsync(); 
        Task<List<ReportEmployee>> GetAllIncCompAsync(Expression<Func<ReportEmployee, bool>> filter); 
    }
}
