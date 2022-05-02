﻿using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPhotoRepository : EfGenericRepository<Photo>, IPhotoDal
    {
    }
}
