using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Intranet
{
    public interface INewsFileService : IGenericService<NewsFile>
    {
        public Task<List<NewsFile>> GetAllByUserIdAsync(int newsId);
    }
}
