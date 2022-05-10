using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Concrete.IntraTicket
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
