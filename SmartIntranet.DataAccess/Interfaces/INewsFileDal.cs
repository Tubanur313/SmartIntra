using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface INewsFileDal : IGenericDal<NewsFile>
    {
        Task<List<NewsFile>> GetAllByUserIdAsync(int newsId);
    }
}
