using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket
{
    public class EfPhotoRepository : EfGenericRepository<Photo>, IPhotoDal
    {
        public async Task<List<Photo>> GetAllByTicketAsync(int ticketId)
        {
            using var context = new IntranetContext();
            return await context.Photos
                .Where(x => x.TicketId == ticketId
                && !x.IsDeleted)
                .OrderByDescending(z => z.Id)
                .ToListAsync();
        }
    }
}
