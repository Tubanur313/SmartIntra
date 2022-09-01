using Microsoft.EntityFrameworkCore;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWatcherRepository : EfGenericRepository<Watcher>, IWatcherDal
    {
        public async Task<List<Watcher>> MyWatchedTicketsAsync(int userId)
        {
            using var context = new IntranetContext();

            return await context.Watchers
           .Where(x => x.IntranetUserId == userId
            && !x.Ticket.IsDeleted)
           .Include(x => x.Ticket)
           .ThenInclude(z => z.Employee)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(x => x.Ticket)
           .ThenInclude(z => z.Supporter)
           .Include(x => x.Ticket)
           .ThenInclude(x => x.CategoryTicket)
           .Include(x => x.Ticket)
           .ThenInclude(x => x.BusinessTravels)
           .Include(x => x.Ticket)
                .ThenInclude(x => x.Permission)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.VacationLeave)
           .OrderByDescending(z => z.Id)
           .ToListAsync();
        }
        public async Task<List<Watcher>> MyWatchedTicketsAsync(int userId, int CategoryTicketId, StatusType statusType)
        {
            using var context = new IntranetContext();
            if (CategoryTicketId > 0 && statusType != 0)
            {
                return await context.Watchers
               .Where(x => x.IntranetUserId == userId
               && x.Ticket.CategoryTicketId == CategoryTicketId
               && x.Ticket.StatusType == statusType
               && !x.Ticket.IsDeleted
              )
               .Include(x => x.Ticket)
               .ThenInclude(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(x => x.Ticket)
               .ThenInclude(z => z.Supporter)
               .Include(x => x.Ticket)
               .ThenInclude(x => x.CategoryTicket)
               .Include(x => x.Ticket)
               .ThenInclude(x => x.BusinessTravels)
               .Include(x => x.Ticket)
                .ThenInclude(x => x.Permission)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.VacationLeave)
               .OrderByDescending(z => z.Id)
               .ToListAsync();
            }
            else if (CategoryTicketId != 0 && statusType == 0)
            {
                return await context.Watchers
                .Where(x => x.IntranetUserId == userId
                && x.Ticket.CategoryTicketId == CategoryTicketId
                && !x.Ticket.IsDeleted
                )
                .Include(x => x.Ticket)
                .ThenInclude(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(x => x.Ticket)
                .ThenInclude(z => z.Supporter)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.CategoryTicket)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.BusinessTravels)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Permission)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.VacationLeave)
                .OrderByDescending(z => z.Id)
                .ToListAsync();
            }
            else if (CategoryTicketId == 0 && statusType != 0)
            {
                return await context.Watchers
                .Where(x => x.IntranetUserId == userId
                && x.Ticket.StatusType == statusType
                && !x.Ticket.IsDeleted
                )
                .Include(x => x.Ticket)
                .ThenInclude(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(x => x.Ticket)
                .ThenInclude(z => z.Supporter)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.CategoryTicket)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.BusinessTravels)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Permission)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.VacationLeave)
                .OrderByDescending(z => z.Id)
                .ToListAsync();
            }
            else
            {
                return await context.Watchers
                .Where(x => x.IntranetUserId == userId
                 && !x.Ticket.IsDeleted)
                .Include(x => x.Ticket)
                .ThenInclude(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(x => x.Ticket)
                .ThenInclude(z => z.Supporter)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.CategoryTicket)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.BusinessTravels)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Permission)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.VacationLeave)
                .OrderByDescending(z => z.Id)
                .ToListAsync();
            }

        }

    }
}
