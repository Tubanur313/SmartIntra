﻿using SmartIntranet.DataAccess.Interfaces.Intranet;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet
{
    public class EfCompanyRepository : EfGenericRepository<Company>, ICompanyDal
    {
    }
}
