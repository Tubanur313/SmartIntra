using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Interfaces.Intranet
{
    public interface IPositionDal : IGenericDal<Position>
    {
        Task<List<Position>> GetAllIncludeAsync();
    }
}
