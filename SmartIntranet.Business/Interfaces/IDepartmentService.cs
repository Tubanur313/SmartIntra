using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface IDepartmentService : IGenericService<Department>
    {
        Task<List<Department>> GetAllIncludeAsync();
    }
}
