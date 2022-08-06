using SmartIntranet.Entities.Concrete.Intranet.Archives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces.Intranet.Archives
{
    public interface IArchiveDal : IGenericDal<Archive>
    {
        Task<List<Archive>> GetAllIncAsync();
    }
}
