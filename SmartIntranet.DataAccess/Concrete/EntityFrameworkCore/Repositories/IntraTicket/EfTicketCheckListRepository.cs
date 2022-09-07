using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket
{
    public class EfTicketCheckListRepository : EfGenericRepository<TicketCheckList>, ITicketCheckListDal
    {
        public async Task<List<TicketCheckList>> FindByIdAllIncAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.TicketCheckLists
                    .Include(tc => tc.Ticket)
                    .Include(tc => tc.CheckList)
                    .Where(tc => tc.Id == id && !tc.IsDeleted)
                    .OrderByDescending(z => z.Id)
                    .ToListAsync();
        }
        public async Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId)
        {
            using var context = new IntranetContext();
            return await context.TicketCheckLists
                    .Include(tc => tc.CheckList)
                    .Where(tc => tc.TicketId == ticketId && !tc.IsDeleted)
                    .OrderByDescending(z => z.Id)
                    .ToListAsync();
        }
    }
}
