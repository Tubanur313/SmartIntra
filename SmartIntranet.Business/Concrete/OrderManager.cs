using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Concrete
{
    public class OrderManager : GenericManager<Order>, IOrderService
    {
        private readonly IGenericDal<Order> _genericDal;
        private readonly IOrderDal _orderDal;

        public OrderManager(IGenericDal<Order> genericDal, IOrderDal orderDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _orderDal = orderDal;
        }

    }
}
