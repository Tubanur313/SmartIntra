using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface IDepartmentService : IGenericService<Department>
    {
        Task<List<Department>> GetAllIncludeAsync();
    }
}
