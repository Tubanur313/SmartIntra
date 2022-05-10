using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface IDepartmentService : IGenericService<Department>
    {
        Task<List<Department>> GetAllIncludeAsync();
    }
}
