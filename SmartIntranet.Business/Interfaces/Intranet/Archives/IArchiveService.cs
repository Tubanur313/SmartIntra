using SmartIntranet.Entities.Concrete.Intranet.Archives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Intranet.Archives
{
    public interface IArchiveService : IGenericService<Archive>
    {
        Task<List<Archive>> GetAllIncAsync();
    }
}
