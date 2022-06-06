using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.Inventary
{
    public class StockImageManager : GenericManager<StockImage>, IStockImageService
    {
        private readonly IGenericDal<StockImage> _genericDal;
        private readonly IStockImageDal _stockImageDal;

        public StockImageManager(IGenericDal<StockImage> genericDal, IStockImageDal stockImageDal) 
            : base(genericDal)
        {
            _genericDal = genericDal;
            _stockImageDal = stockImageDal;
        }

        public Task<List<StockImage>> GetAllByStockAsync(int stockId)
        {
            return _stockImageDal.GetAllByStockAsync(stockId);
        }
    }
}
