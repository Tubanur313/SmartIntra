using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<StockDiscuss>> GetAllByTicketAsync(int stockId)
        {
            return await _stockDiscussDal.GetAllByTicketAsync(stockId);
        }

        public async Task<StockDiscuss> GetAllIncludeAsync(int id)
        {
            return await _stockDiscussDal.GetAllIncludeAsync(id);
        }
    }
}
