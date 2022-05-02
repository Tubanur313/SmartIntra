using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DTO.DTOs.ConfirmTicketUserDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface IConfirmTicketUserService : IGenericService<ConfirmTicketUser>
    {
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId, int categoryId, StatusType statusType);
        Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId);
    }
}
