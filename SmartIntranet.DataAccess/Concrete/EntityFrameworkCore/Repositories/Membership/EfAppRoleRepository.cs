using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppRoleRepository : EfGenericRepository<IntranetRole>, IAppRoleDal
    {
        
    }
}
