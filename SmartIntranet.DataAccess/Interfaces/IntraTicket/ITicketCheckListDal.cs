using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITicketCheckListDal : IGenericDal<TicketCheckList>
    {
        Task<List<TicketCheckList>> FindByIdAllIncAsync(int id);
        Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId);
    }
}
