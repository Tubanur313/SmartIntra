using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface ITicketOrderService : IGenericService<TicketOrder>
    {
        Task<List<TicketOrder>> GetAllIncludeAsync();
        Task<List<TicketOrder>> GetAllIncludeAsync(Expression<Func<TicketOrder, bool>> filter);
        Task<List<TicketOrder>> FindOrdersByTicketId(int id);
    }
}
