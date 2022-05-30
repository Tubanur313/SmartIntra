using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IPositionDal : IGenericDal<Position>
    {
        Task<List<Position>> GetAllIncludeAsync();
    }
}
