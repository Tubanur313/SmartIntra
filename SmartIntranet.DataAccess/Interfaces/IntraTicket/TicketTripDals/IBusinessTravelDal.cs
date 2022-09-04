using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket.TicketTripDals
{
    public interface IBusinessTravelDal : IGenericDal<BusinessTravel>
    {
        Task<List<BusinessTravel>> FindByTicketIdIncludeAsync(int ticketId);
        Task<BusinessTravel> FindByTicketIdInclAsync(int ticketId);
    }
}
