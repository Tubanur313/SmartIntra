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
    public class EfConfirmTicketUserRepository : EfGenericRepository<ConfirmTicketUser>, IConfirmTicketUserDal
    {
        public async Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId)
        {
            using var context = new IntranetContext();
            return await context.ConfirmTicketUsers
                .Where(x => x.IntranetUserId == userId
                && x.Ticket.IsDeleted == false)
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
        public async Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId, int categoryId, StatusType statusType)
        {
            using var context = new IntranetContext();
            if (categoryId > 0 && statusType != 0)
            {
                return await context.ConfirmTicketUsers
               .Where(x => x.IntranetUserId == userId
               && x.Ticket.CategoryTicketId == categoryId
               && x.Ticket.StatusType == statusType
               && x.Ticket.IsDeleted == false
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
            else if (categoryId != 0 && statusType == 0)
            {
                return await context.ConfirmTicketUsers
                .Where(x => x.IntranetUserId == userId
                && x.Ticket.CategoryTicketId == categoryId
                && x.Ticket.IsDeleted == false)
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
            else if (categoryId == 0 && statusType != 0)
            {
                return await context.ConfirmTicketUsers
                .Where(x => x.IntranetUserId == userId
                && x.Ticket.StatusType == statusType
                && x.Ticket.IsDeleted == false)
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
                return await context.ConfirmTicketUsers
                .Where(x => x.IntranetUserId == userId
                && x.Ticket.IsDeleted == false)
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
