using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDepartmentRepository : EfGenericRepository<Department>, IDepartmentDal
    {
        public async Task<List<Department>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Departments
                .Where(z => !z.IsDeleted)
                .Include(z => z.Company)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }

}
