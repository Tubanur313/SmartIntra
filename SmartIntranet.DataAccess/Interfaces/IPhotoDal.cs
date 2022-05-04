using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IPhotoDal : IGenericDal<Photo>
    {
        Task<List<Photo>> GetAllByTicketAsync(int ticketId);
    }
}
