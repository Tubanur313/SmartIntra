using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace SmartIntranet.Business.Concrete.IntraTicket
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

        public async Task<List<TicketOrder>> GetAllIncludeAsync(int ticketId)
        {
            return await _ticketOrderDal.GetAllIncludeAsync(ticketId);
        }
    }
}
