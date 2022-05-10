using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface ITicketCheckListService : IGenericService<TicketCheckList>
    {
        Task<List<TicketCheckList>> FindByIdAllIncAsync(int id);
        Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId);
    }
}
