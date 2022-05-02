using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        Task<List<Ticket>> GetNonRedirectedAsync(int categoryId, StatusType statusType);
        Task<Ticket> FindAllIncludeForInfoAsync(int id);
        Task<Ticket> FindForConfirmAsync(int id);
        Task<Ticket> FindForWatchersAsync(int id);
        Task<Ticket> FindForCheckingsAsync(int id);
    }
}
