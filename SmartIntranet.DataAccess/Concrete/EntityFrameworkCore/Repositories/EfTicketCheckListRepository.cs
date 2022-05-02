
using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfTicketCheckListRepository : EfGenericRepository<TicketCheckList>, ITicketCheckListDal
    {
        public async Task<List<TicketCheckList>> FindByIdAllIncAsync(int id)
        {
            using (var context = new IntranetContext()) 
            return await context.TicketCheckLists
                    .Include(tc => tc.Ticket)
                    .Include(tc=>tc.CheckList)
                    .Where(tc=>tc.Id==id&&tc.IsDeleted==false).ToListAsync();
        }
        public async Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId)
        {
            using (var context = new IntranetContext())
                return await context.TicketCheckLists
                        .Include(tc => tc.CheckList)
                        .Where(tc => tc.TicketId == ticketId && tc.IsDeleted == false).ToListAsync();
        }
    }
}
