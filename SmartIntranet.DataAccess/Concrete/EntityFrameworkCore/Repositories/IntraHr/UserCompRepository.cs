using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraHr
{
    public class UserCompRepository : EfGenericRepository<UserComp>, IUserCompDal
    {
    }
}
