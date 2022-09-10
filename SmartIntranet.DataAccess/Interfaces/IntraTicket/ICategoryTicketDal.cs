using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket
{
    public interface ICategoryTicketDal : IGenericDal<CategoryTicket>
    {
        Task<List<CategoryTicket>> GetAllIncludeAsync(bool asnotrack=false);
        Task<CategoryTicket> GetIncludeAsync(int id);
    }
}
