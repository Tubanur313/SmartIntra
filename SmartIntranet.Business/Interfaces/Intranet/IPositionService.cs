using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface IPositionService : IGenericService<Position>
    {
        Task<List<Position>> GetAllIncludeAsync();
    }
}
