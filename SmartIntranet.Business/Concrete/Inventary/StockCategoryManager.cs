using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;

namespace SmartIntranet.Business.Concrete.Inventary
{
    public class StockCategoryManager : GenericManager<StockCategory>, IStockCategoryService
    {
        private readonly IGenericDal<StockCategory> _genericDal;
        private readonly IStockCategoryDal _stockCategoryDal;

        public StockCategoryManager(IGenericDal<StockCategory> genericDal, IStockCategoryDal stockCategoryDal) : base(genericDal)
        {
            _stockCategoryDal = stockCategoryDal;
            _genericDal = genericDal;
        }
    }
}
