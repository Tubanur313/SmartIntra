using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITicketDal : IGenericDal<Ticket>
    {
        Task<List<Ticket>> GetAllIncludeAsync(int id);
        Task<Ticket> GetIncludeMailAsync(int id);
        Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId);
        Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId, int categoryId, StatusType statusType);
        Task<List<Ticket>> GetNonRedirectedAsync();
        Task<List<Ticket>> GetNonRedirectedAsync(int categoryId, StatusType statusType, int companyId);
        Task<Ticket> FindAllIncludeForInfoAsync(int id);
        Task<Ticket> FindForConfirmAsync(int id);
        Task<Ticket> FindForWatchersAsync(int id);
        Task<Ticket> FindForCheckingsAsync(int id);
        Task<List<Ticket>> GetForAdminAsync();
        Task<List<Ticket>> GetForAdminAsync(int categoryId, StatusType statusType, int companyId);
        Task<List<Ticket>> GetByDepartmentAllIncAsync(int departId);
    }
}
