using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Interfaces.Intranet
{
    public interface IDepartmentDal : IGenericDal<Department>
    {
        Task<List<Department>> GetAllIncludeAsync();
    }
}
