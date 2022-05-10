using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface IDiscussionService : IGenericService<Discussion>
    {
        Task<Discussion> GetAllIncludeAsync(int id);
        Task<List<Discussion>> GetAllByTicketAsync(int ticketId);
    }
}
