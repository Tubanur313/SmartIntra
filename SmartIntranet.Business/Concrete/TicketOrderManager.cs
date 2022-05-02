using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class TicketOrderManager : GenericManager<TicketOrder>, ITicketOrderService
    {
        private readonly IGenericDal<TicketOrder> _genericDal;
        private readonly ITicketOrderDal _ticketOrderDal;

        public TicketOrderManager(IGenericDal<TicketOrder> genericDal, ITicketOrderDal ticketOrderDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _ticketOrderDal = ticketOrderDal;
        }

        public async Task<List<TicketOrder>> FindOrdersByTicketId(int id)
        {
            return await _ticketOrderDal.FindOrdersByTicketId(id);
        }

        public async Task<List<TicketOrder>> GetAllIncludeAsync()
        {
            return await _ticketOrderDal.GetAllIncludeAsync();
        }

        public async Task<List<TicketOrder>> GetAllIncludeAsync(Expression<Func<TicketOrder, bool>> filter)
        {
            return await _ticketOrderDal.GetAllIncludeAsync(filter);
        }
    }
}
