using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IDepartmentDal : IGenericDal<Department>
    {
        Task<List<Department>> GetAllIncludeAsync();
    }
}
