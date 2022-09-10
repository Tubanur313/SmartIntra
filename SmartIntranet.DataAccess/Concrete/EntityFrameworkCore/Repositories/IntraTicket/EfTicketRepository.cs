using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.IntraTicket
{
    public class EfTicketRepository : EfGenericRepository<Ticket>, ITicketDal
    {
        public async Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId)
        {
           await using var context = new IntranetContext();
            if (userId != 0)
            {
                return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
               .OrderByDescending(x => x.Id).ToListAsync();
            }
            else
            {
                return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
               .OrderByDescending(x => x.Id).ToListAsync();
            }

        }
        public async Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId, int CategoryTicketId, StatusType statusType)
        {
            using var context = new IntranetContext();
            if (userId != 0)
            {
                if (CategoryTicketId > 0 && statusType != 0)
                {
                    return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId)
               .Where(x =>
                 x.CategoryTicketId == CategoryTicketId
                 && x.StatusType == statusType
                 && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId > 0 && statusType == 0)
                {
                    return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId)
               .Where(x =>
                 x.CategoryTicketId == CategoryTicketId && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId == 0 && statusType != 0)
                {
                    return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId)
               .Where(x =>
                 x.StatusType == statusType && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await context.Tickets
                   .Where(x => x.SupporterId == userId || x.EmployeeId == userId && !x.IsDeleted)
                   .Include(z => z.Employee)
                   .ThenInclude(z => z.Company)
                   .ThenInclude(z => z.Departments)
                   .ThenInclude(z => z.Positions)
                   .Include(z => z.Supporter)
                   .Include(z => z.CategoryTicket)
                   .OrderByDescending(x => x.Id).ToListAsync();
                }
            }
            else
            {
                if (CategoryTicketId > 0 && statusType != 0)
                {
                    return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId)
               .Where(x =>
                 x.CategoryTicketId == CategoryTicketId
                 && x.StatusType == statusType
                 && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId > 0 && statusType == 0)
                {
                    return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId)
               .Where(x =>
                 x.CategoryTicketId == CategoryTicketId && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId == 0 && statusType != 0)
                {
                    return await context.Tickets
               .Where(x => x.SupporterId == userId || x.EmployeeId == userId)
               .Where(x =>
                 x.StatusType == statusType && !x.IsDeleted)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .Include(z => z.CategoryTicket)
               .OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await context.Tickets
                   .Where(x => x.SupporterId == userId || x.EmployeeId == userId && !x.IsDeleted)
                   .Include(z => z.Employee)
                   .ThenInclude(z => z.Company)
                   .ThenInclude(z => z.Departments)
                   .ThenInclude(z => z.Positions)
                   .Include(z => z.Supporter)
                   .Include(z => z.CategoryTicket)
                   .OrderByDescending(x => x.Id).ToListAsync();
                }
            }
        }
        public async Task<Ticket> FindAllIncludeForInfoAsync(int id)
        {
            await using var context = new IntranetContext();
            return await context.Tickets
                .Where(z => z.Id == id && !z.IsDeleted)
                .Include(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.Supporter)
                .Include(z => z.CategoryTicket)
                .Include(z => z.TicketOrders)
                .ThenInclude(z => z.Order)
                .Include(z => z.BusinessTravels)
                .ThenInclude(x=>x.Place)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Ticket>> GetAllIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(z => z.IsDeleted == false && z.Id == id)
                .Include(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.Supporter)
                .Include(z => z.CategoryTicket)
                .OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<Ticket> GetIncludeMail(int id)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(x => x.Id == id)
                .Include(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.Supporter)
                .Include(z => z.CategoryTicket)
                .Include(z => z.Photos)
                .Include(z => z.TicketOrders)
                .ThenInclude(z => z.Order)
                .Include(z => z.TicketCheckLists)
                .ThenInclude(z => z.CheckList)
                .Include(z => z.ConfirmTicketUsers)
                .ThenInclude(z => z.IntranetUser)
                .Include(z => z.Watchers)
                .Include(z => z.Discussions)
                .FirstOrDefaultAsync();
        }
        public async Task<List<Ticket>> GetNonRedirectedAsync()
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(u => u.SupporterId == null && !u.IsDeleted)
                .Include(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.Supporter)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.CategoryTicket)
                .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                .OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<List<Ticket>> GetNonRedirectedAsync(int CategoryTicketId, StatusType statusType, int companyId)
        {
            using var context = new IntranetContext();
            if (companyId != 0)
            {
                if (CategoryTicketId > 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.CategoryTicketId == CategoryTicketId
                    && x.StatusType == statusType
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId != 0 && statusType == 0)
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.CategoryTicketId == CategoryTicketId
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId == 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.StatusType == statusType
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
            }
            else
            {
                if (CategoryTicketId > 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.CategoryTicketId == CategoryTicketId
                    && x.StatusType == statusType
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId != 0 && statusType == 0)
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.CategoryTicketId == CategoryTicketId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId == 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && x.StatusType == statusType
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await context.Tickets.Where(x => x.SupporterId == null
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
            }

        }
        public async Task<Ticket> FindForConfirmAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(z => z.IsDeleted == false && z.Id == id)
                .Include(z => z.ConfirmTicketUsers)
                .ThenInclude(z => z.IntranetUser)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .FirstOrDefaultAsync();
        }
        public async Task<Ticket> FindForWatchersAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(z => z.IsDeleted == false && z.Id == id)
                .Include(z => z.Watchers)
                .ThenInclude(z => z.IntranetUser)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .FirstOrDefaultAsync();
        }
        public async Task<Ticket> FindForCheckingsAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(z => z.IsDeleted == false && z.Id == id)
                .Include(z => z.TicketCheckLists)
                .ThenInclude(z => z.CheckList)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Ticket>> GetForAdminAsync()
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(u => u.IsDeleted == false)
                .Include(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.Supporter)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.CategoryTicket)
                .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                .OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<List<Ticket>> GetForAdminAsync(int CategoryTicketId, StatusType statusType, int companyId)
        {
            using var context = new IntranetContext();
            if (companyId != 0)
            {
                if (CategoryTicketId > 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x =>
                    x.CategoryTicketId == CategoryTicketId
                    && x.StatusType == statusType
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId != 0 && statusType == 0)
                {
                    return await context.Tickets.Where(x =>
                    x.CategoryTicketId == CategoryTicketId
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId == 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x =>
                    x.StatusType == statusType
                    && x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await context.Tickets.Where(x =>
                    x.Employee.CompanyId == companyId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
            }
            else
            {
                if (CategoryTicketId > 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x =>
                    x.CategoryTicketId == CategoryTicketId
                    && x.StatusType == statusType
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId != 0 && statusType == 0)
                {
                    return await context.Tickets.Where(x =>
                    x.CategoryTicketId == CategoryTicketId
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (CategoryTicketId == 0 && statusType != 0)
                {
                    return await context.Tickets.Where(x =>
                    x.StatusType == statusType
                    && !x.IsDeleted)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await context.Tickets.Where(x =>
                     x.IsDeleted == false)
                    .Include(z => z.Employee)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.Supporter)
                    .ThenInclude(z => z.Company)
                    .ThenInclude(z => z.Departments)
                    .ThenInclude(z => z.Positions)
                    .Include(z => z.CategoryTicket)
                    .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                    .OrderByDescending(x => x.Id).ToListAsync();
                }
            }

        }
        public async Task<List<Ticket>> GetByDepartmentAllIncAsync(int departId)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(x => !x.IsDeleted)
                .Include(x => x.Supporter)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .Where(z => z.Supporter.DepartmentId == departId)
                .OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<List<Ticket>> GetByUserDepartmentAllIncAsync(int departId)
        {
            using var context = new IntranetContext();
            return await context.Tickets
                .Where(z => z.Employee.DepartmentId == departId || z.Supporter.DepartmentId == departId)
                .Include(z => z.Employee)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(x => x.Supporter)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .ThenInclude(z => z.Positions)
                .Include(z => z.CategoryTicket)
                .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
                .OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<List<Ticket>> GetByUserDepartmentAllIncAsync(int departId, int categoryId, StatusType statusType)
        {
            using var context = new IntranetContext();
            if (categoryId > 0 && statusType != 0)
            {
                return await context.Tickets
           .Where(x => x.Supporter.DepartmentId == departId || x.Employee.DepartmentId == departId)
           .Where(x =>
             x.CategoryTicketId == categoryId
             && x.StatusType == statusType
             && !x.IsDeleted)
           .Include(z => z.Employee)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(z => z.Supporter)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(z => z.CategoryTicket)
           .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
           .OrderByDescending(x => x.Id).ToListAsync();
            }
            else if (categoryId > 0 && statusType == 0)
            {
                return await context.Tickets
           .Where(x => x.Supporter.DepartmentId == departId || x.Employee.DepartmentId == departId)
           .Where(x =>
             x.CategoryTicketId == categoryId && !x.IsDeleted)
           .Include(z => z.Employee)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(z => z.Supporter)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(z => z.CategoryTicket)
           .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
           .OrderByDescending(x => x.Id).ToListAsync();
            }
            else if (categoryId == 0 && statusType != 0)
            {
                return await context.Tickets
           .Where(x => x.Supporter.DepartmentId == departId || x.Employee.DepartmentId == departId)
           .Where(x =>
             x.StatusType == statusType && !x.IsDeleted)
           .Include(z => z.Employee)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(z => z.Supporter)
           .ThenInclude(z => z.Company)
           .ThenInclude(z => z.Departments)
           .ThenInclude(z => z.Positions)
           .Include(z => z.CategoryTicket)
           .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
           .OrderByDescending(x => x.Id).ToListAsync();
            }
            else
            {
                return await context.Tickets
               .Where(x => x.Supporter.DepartmentId == departId || x.Employee.DepartmentId == departId)
               .Include(z => z.Employee)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.Supporter)
               .ThenInclude(z => z.Company)
               .ThenInclude(z => z.Departments)
               .ThenInclude(z => z.Positions)
               .Include(z => z.CategoryTicket)
               .Include(z => z.BusinessTravels).Include(z => z.VacationLeave).Include(z => z.Permission)
               .OrderByDescending(x => x.Id).ToListAsync();
            }
        }

    }
}