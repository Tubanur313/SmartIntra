using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs.TicketCheckListDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface ITicketCheckListService : IGenericService<TicketCheckList>
    {
        Task<List<TicketCheckList>> FindByIdAllIncAsync(int id);
        Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId);
    }
}
