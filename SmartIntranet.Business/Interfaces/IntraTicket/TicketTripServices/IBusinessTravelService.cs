
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.Business.Interfaces.IntraTicket.TicketTripServices
{
    public interface IBusinessTravelService : IGenericService<BusinessTravel>
    {
        Task<List<BusinessTravel>> FindByTicketIdIncludeAsync(int ticketId);
        Task<BusinessTravel> FindByTicketIdInclAsync(int ticketId);
    }
}
