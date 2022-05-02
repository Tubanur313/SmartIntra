using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class NewsFileManager : GenericManager<NewsFile>, INewsFileService
    {
        private readonly IGenericDal<NewsFile> _genericDal;
        private readonly INewsFileDal _newsFileDal;

        public NewsFileManager(IGenericDal<NewsFile> genericDal, INewsFileDal newsFileDal) : base(genericDal)
        {
            _newsFileDal = newsFileDal;
            _genericDal = genericDal;
        }

        public async Task<List<NewsFile>> GetAllByUserIdAsync(int newsId)
        {
            return await _newsFileDal.GetAllByUserIdAsync(newsId);
        }

    }
}
