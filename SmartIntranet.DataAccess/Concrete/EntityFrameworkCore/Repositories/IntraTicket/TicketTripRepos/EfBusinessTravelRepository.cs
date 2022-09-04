using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraTicket.TicketTripDals;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket.TicketTripRepos
{
    public class EfBusinessTravelRepository : EfGenericRepository<BusinessTravel>, IBusinessTravelDal
    {
        public async Task<List<BusinessTravel>> FindByTicketIdIncludeAsync(int ticketId)
        {
            await using var context = new IntranetContext();
            return await context.BusinessTravels.Include(x=>x.Place)
                .Where(x=>x.TicketId== ticketId).ToListAsync();
        }

        public async Task<BusinessTravel> FindByTicketIdInclAsync(int ticketId)
        {
            await using var context = new IntranetContext();
            return context.BusinessTravels.Include(x => x.Place).FirstOrDefault(x => x.TicketId== ticketId);
        }
    }
}
