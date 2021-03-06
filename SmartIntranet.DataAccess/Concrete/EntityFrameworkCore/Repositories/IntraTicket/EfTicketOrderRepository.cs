using Microsoft.EntityFrameworkCore;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfTicketOrderRepository : EfGenericRepository<TicketOrder>, ITicketOrderDal
    {
        public async Task<List<TicketOrder>> FindOrdersByTicketId(int Id)
        {
            using var context = new IntranetContext();
            return await context.TicketOrders
               .Where(z => z.TicketId == Id)
               .Include(z => z.Order)
               .Include(z => z.Ticket)
               .ToListAsync();
        }

        public async Task<List<TicketOrder>> GetAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.TicketOrders
                .Where(z => z.IsDeleted == false)
                .Include(z => z.Order)
                .ToListAsync();
        }

        public async Task<List<TicketOrder>> GetAllIncludeAsync(int ticketId)
        {
            using var context = new IntranetContext();
            return await context.TicketOrders
                .Where(z => z.IsDeleted == false && z.TicketId == ticketId)
                .Include(z => z.Order)
                .ToListAsync();
        }
    }
}
