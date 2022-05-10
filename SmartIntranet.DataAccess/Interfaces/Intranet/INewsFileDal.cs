using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface INewsFileDal : IGenericDal<NewsFile>
    {
        Task<List<NewsFile>> GetAllByUserIdAsync(int newsId);
    }
}
