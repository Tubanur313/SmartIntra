using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.Intranet
{
    public class NewsManager : GenericManager<News>, INewsService
    {
        private readonly IGenericDal<News> _genericDal;
        private readonly INewsDal _newsDal;

        public NewsManager(IGenericDal<News> genericDal, INewsDal newsDal) : base(genericDal)
        {
            _newsDal = newsDal;
            _genericDal = genericDal;
        }

        public async Task<News> FindByIdIncludeAllAsync(int id)
        {
            return await _newsDal.FindByIdIncludeAllAsync(id);
        }

        public async Task<List<News>> GetAllWithIncludeAsync()
        {
            return await _newsDal.GetAllWithIncludeAsync();
        }
        public async Task<List<News>> GetAllWithIncludeNonDeleteAsync()
        {
            return await _newsDal.GetAllWithIncludeNonDeleteAsync();
        }
    }
}
