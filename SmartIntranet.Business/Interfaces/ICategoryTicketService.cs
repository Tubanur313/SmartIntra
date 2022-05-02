using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface ICategoryTicketService : IGenericService<CategoryTicket>
    {
        Task<List<CategoryTicket>> GetAllIncludeAsync();
        Task<CategoryTicket> GetIncludeAsync(int id);
    }
}
