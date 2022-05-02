using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IConfirmTicketUserDal : IGenericDal<ConfirmTicketUser>
    {
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId);
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId, int categoryId, StatusType statusType);
    }
}
