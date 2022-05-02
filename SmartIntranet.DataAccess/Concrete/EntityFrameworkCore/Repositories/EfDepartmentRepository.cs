
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
    public class EfDepartmentRepository : EfGenericRepository<Department>, IDepartmentDal
    {
        public async Task<List<Department>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Departments
                .Where(z => z.IsDeleted == false)
                .Include(z => z.Company)
                .ToListAsync(); 
        }
    }

}
