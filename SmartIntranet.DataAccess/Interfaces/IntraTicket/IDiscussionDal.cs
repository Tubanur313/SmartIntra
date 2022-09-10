using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket
{
    public interface IDiscussionDal : IGenericDal<Discussion>
    {
        Task<Discussion> GetAllIncludeAsync(int id);
        Task<List<Discussion>> GetAllByTicketAsync(int ticketId);
    }
}
