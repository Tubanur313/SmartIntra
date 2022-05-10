using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface IConfirmTicketUserService : IGenericService<ConfirmTicketUser>
    {
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId, int categoryId, StatusType statusType);
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId);
    }
}
