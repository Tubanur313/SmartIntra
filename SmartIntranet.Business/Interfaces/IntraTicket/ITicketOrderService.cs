using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface ITicketOrderService : IGenericService<TicketOrder>
    {
        Task<List<TicketOrder>> GetAllIncludeAsync();
        Task<List<TicketOrder>> GetAllIncludeAsync(int ticketId);
        Task<List<TicketOrder>> FindOrdersByTicketId(int id);
    }
}
