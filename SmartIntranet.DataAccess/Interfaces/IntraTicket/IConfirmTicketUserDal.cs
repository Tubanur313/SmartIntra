using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces.IntraTicket
{
    public interface IConfirmTicketUserDal : IGenericDal<ConfirmTicketUser>
    {
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId);
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId, int categoryId, StatusType statusType);
    }
}
