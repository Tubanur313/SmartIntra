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
    }
}
