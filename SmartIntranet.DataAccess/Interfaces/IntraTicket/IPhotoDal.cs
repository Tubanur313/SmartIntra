using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket
{
    public interface IPhotoDal : IGenericDal<Photo>
    {
        Task<List<Photo>> GetAllByTicketAsync(int ticketId);
    }
}
