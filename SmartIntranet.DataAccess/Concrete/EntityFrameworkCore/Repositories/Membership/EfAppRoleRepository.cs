using SmartIntranet.DataAccess.Interfaces.Membership;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Membership
{
    public class EfAppRoleRepository : EfGenericRepository<IntranetRole>, IAppRoleDal
    {
        
    }
}
