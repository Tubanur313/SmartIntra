using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs.PhotoDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface IPhotoService : IGenericService<Photo>
    {
        Task<List<Photo>> GetAllByTicketAsync(int ticketId);
    }
}
