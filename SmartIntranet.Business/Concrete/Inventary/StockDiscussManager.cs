using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;

namespace SmartIntranet.Business.Concrete.Inventary
{
    public class StockDiscussManager : GenericManager<StockDiscuss>, IStockDiscussService
    {
        private readonly IGenericDal<StockDiscuss> _genericDal;
        private readonly IStockDiscussDal _stockDiscussDal;

        public StockDiscussManager(IGenericDal<StockDiscuss> genericDal, IStockDiscussDal stockDiscussDal) 
            : base(genericDal)
        {
            _genericDal = genericDal;
            _stockDiscussDal = stockDiscussDal;
        }
    }
}
