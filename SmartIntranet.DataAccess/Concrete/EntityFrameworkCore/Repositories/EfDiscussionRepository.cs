
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDiscussionRepository : EfGenericRepository<Discussion>, IDiscussionDal
    {
        public async Task<List<Discussion>> GetAllByTicketAsync(int ticketId)
        {
            using var context = new IntranetContext();
            return await context.Discussions
                .Where(x => x.TicketId == ticketId)
                .OrderBy(x => x.Id)
                .Include(x => x.IntranetUser)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .ToListAsync();
        }
        public async Task<Discussion> GetAllIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Discussions
                .OrderBy(x => x.Id)
                .Include(x => x.IntranetUser)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
