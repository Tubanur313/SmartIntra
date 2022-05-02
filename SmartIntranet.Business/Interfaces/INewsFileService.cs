using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface INewsFileService : IGenericService<NewsFile>
    {
        public Task<List<NewsFile>> GetAllByUserIdAsync(int newsId);
    }
}
