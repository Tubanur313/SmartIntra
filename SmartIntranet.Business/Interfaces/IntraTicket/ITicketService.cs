using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface ITicketService : IGenericService<Ticket>
    {
        Task<List<Ticket>> GetAllIncludeAsync(int id);
        Task<Ticket> GetIncludeMail(int id);
        Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId);
        Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId, int categoryId, StatusType statusType);
        Task<List<Ticket>> GetNonRedirectedAsync();
        Task<List<Ticket>> GetNonRedirectedAsync(int categoryId, StatusType statusType, int companyId);
        Task<Ticket> FindAllIncludeForInfoAsync(int id);
        Task<Ticket> FindForConfirmAsync(int id);
        Task<Ticket> FindForWatchersAsync(int id);
        Task<Ticket> FindForCheckingsAsync(int id);
        Task<List<Ticket>> GetForAdminAsync();
        Task<List<Ticket>> GetForAdminAsync(int categoryTicketId, StatusType statusType, int companyId);
        Task<List<Ticket>> GetByDepartmentAllIncAsync(int id);
        Task<List<Ticket>> GetByUserDepartmentAllIncAsync(int departmentId);
        Task<List<Ticket>> GetByUserDepartmentAllIncAsync(int departmentId, int categoryId, StatusType statusType);

    }
}
