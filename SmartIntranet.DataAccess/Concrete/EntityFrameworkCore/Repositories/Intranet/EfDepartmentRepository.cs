using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Intranet;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet
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
