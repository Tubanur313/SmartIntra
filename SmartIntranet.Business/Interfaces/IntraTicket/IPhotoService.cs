using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface IPhotoService : IGenericService<Photo>
    {
        Task<List<Photo>> GetAllByTicketAsync(int ticketId);
    }
}
