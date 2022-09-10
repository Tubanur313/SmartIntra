using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket
{
    public interface ITicketOrderDal : IGenericDal<TicketOrder>
    {
        Task<List<TicketOrder>> GetAllIncludeAsync();
        Task<List<TicketOrder>> GetAllIncludeAsync(int ticketId);
        Task<List<TicketOrder>> FindOrdersByTicketId(int Id);
    }
}
