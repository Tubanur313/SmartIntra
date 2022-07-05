using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public Task<List<Stock>> FilterByStatusCategCompAsync(int stockCategoryId, int companyId, StockStatus StockStatus)
        {
            return _stockDal.FilterByStatusCategCompAsync(stockCategoryId, companyId, StockStatus);
        }

        public Task<Stock> FindByIdIncludeAsync(int id)
        {
            return _stockDal.FindByIdIncludeAsync(id);
        }

        public Task<List<Stock>> GetStockAllIncludeAsync()
        {
            return _stockDal.GetStockAllIncludeAsync();
        }
    }
}
