using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ICategoryTicketDal : IGenericDal<CategoryTicket>
    {
        Task<List<CategoryTicket>> GetAllIncludeAsync();
        Task<CategoryTicket> GetIncludeAsync(int id);
    }
}
