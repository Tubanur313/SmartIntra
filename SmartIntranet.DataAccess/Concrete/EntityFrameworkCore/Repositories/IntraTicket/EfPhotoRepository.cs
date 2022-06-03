using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPhotoRepository : EfGenericRepository<Photo>, IPhotoDal
    {
        public async Task<List<Photo>> GetAllByTicketAsync(int ticketId)
        {
            using var context = new IntranetContext();
            return await context.Photos
                .Where(x => x.TicketId == ticketId
                && !x.IsDeleted)
                .ToListAsync();
        }
    }
}
