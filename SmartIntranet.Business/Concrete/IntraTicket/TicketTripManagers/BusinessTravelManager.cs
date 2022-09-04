using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraTicket.TicketTripServices;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraTicket.TicketTripDals;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.Business.Concrete.IntraTicket.TicketTripManagers
{
    public class BusinessTravelManager : GenericManager<BusinessTravel>, IBusinessTravelService
    {
        private readonly IGenericDal<BusinessTravel> _genericDal;
        private readonly IBusinessTravelDal _businessTravelDal;
        public BusinessTravelManager(IGenericDal<BusinessTravel> genericDal, IBusinessTravelDal businessTravelDal) : base(genericDal)
        {
            _businessTravelDal = businessTravelDal;
            _genericDal = genericDal;
        }

        public async Task<List<BusinessTravel>> FindByTicketIdIncludeAsync(int ticketId)
        {
            return await _businessTravelDal.FindByTicketIdIncludeAsync(ticketId);
        }

        public async Task<BusinessTravel> FindByTicketIdInclAsync(int ticketId)
        {
            return await _businessTravelDal.FindByTicketIdInclAsync(ticketId);
        }
    }
}
