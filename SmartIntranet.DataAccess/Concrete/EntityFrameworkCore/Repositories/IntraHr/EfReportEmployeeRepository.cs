using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportEmployeeRepository : EfGenericRepository<ReportEmployee>, IReportEmployeeDal
    {
        public async Task<List<ReportEmployee>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.ReportEmployees.Include(x => x.Company).ToListAsync();
        }

        public async Task<List<ReportEmployee>> GetAllIncCompAsync(Expression<Func<ReportEmployee, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.ReportEmployees.Include(x=>x.Company).Where(filter).ToListAsync();

        }
    }

}
