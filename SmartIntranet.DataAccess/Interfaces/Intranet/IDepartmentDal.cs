using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IDepartmentDal : IGenericDal<Department>
    {
        Task<List<Department>> GetAllIncludeAsync();
    }
}
