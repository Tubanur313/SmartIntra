using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Interfaces.Intranet
{
    public interface INewsFileDal : IGenericDal<NewsFile>
    {
        Task<List<NewsFile>> GetAllByUserIdAsync(int newsId);
    }
}
