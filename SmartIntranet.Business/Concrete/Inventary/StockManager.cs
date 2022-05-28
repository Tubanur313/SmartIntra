using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;

namespace SmartIntranet.Business.Concrete.Inventary
{
    public class StockManager : GenericManager<Stock>, IStockService
    {
        private readonly IGenericDal<Stock> _genericDal;
        private readonly IStockDal _stockDal;

        public StockManager(IGenericDal<Stock> genericDal, IStockDal stockDal) : base(genericDal)
        {
            _stockDal = stockDal;
            _genericDal = genericDal;
        }
    }
}
