using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Core.Entities.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.IntraTicket
{
    public class TicketManager : GenericManager<Ticket>, ITicketService
    {
        private readonly IGenericDal<Ticket> _genericDal;
        private readonly ITicketDal _ticketDal;

        public TicketManager(IGenericDal<Ticket> genericDal, ITicketDal ticketDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _ticketDal = ticketDal;
        }

        public async Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId)
        {
            return await _ticketDal.GetListedBySignInUserIdAsync(userId);
        }
        public async Task<List<Ticket>> GetListedBySignInUserIdAsync(int userId, int categoryId, StatusType statusType)
        {
            return await _ticketDal.GetListedBySignInUserIdAsync(userId, categoryId, statusType);
        }
        public async Task<Ticket> FindAllIncludeForInfoAsync(int id)
        {
            return await _ticketDal.FindAllIncludeForInfoAsync(id);
        }

        public async Task<Ticket> FindForConfirmAsync(int id)
        {
            return await _ticketDal.FindForConfirmAsync(id);
        }
        public async Task<Ticket> FindForWatchersAsync(int id)
        {
            return await _ticketDal.FindForWatchersAsync(id);
        }
        public async Task<Ticket> FindForCheckingsAsync(int id)
        {
            return await _ticketDal.FindForCheckingsAsync(id);
        }

        public async Task<List<Ticket>> GetAllIncludeAsync(int id)
        {
            return await _ticketDal.GetAllIncludeAsync(id);
        }

        public async Task<Ticket> GetIncludeMailAsync(int id)
        {
            return await _ticketDal.GetIncludeMailAsync(id);
        }

        public async Task<List<Ticket>> GetNonRedirectedAsync()
        {
            return await _ticketDal.GetNonRedirectedAsync();
        }

        public async Task<List<Ticket>> GetNonRedirectedAsync(int categoryId, StatusType statusType, int companyId)
        {
            return await _ticketDal.GetNonRedirectedAsync(categoryId, statusType, companyId);
        }

        public async Task<List<Ticket>> GetForAdminAsync()
        {
            return await _ticketDal.GetForAdminAsync();
        }

        public async Task<List<Ticket>> GetForAdminAsync(int categoryId, StatusType statusType, int companyId)
        {
            return await _ticketDal.GetForAdminAsync(categoryId, statusType, companyId);
        }

        public async Task<List<Ticket>> GetByDepartmentAllIncAsync(int departId)
        {
            return await _ticketDal.GetByDepartmentAllIncAsync(departId);
        }
        public async Task<List<Ticket>> GetByUserDepartmentAllIncAsync(int departmentId)
        {
            return await _ticketDal.GetByUserDepartmentAllIncAsync(departmentId);

        }

        public async Task<List<Ticket>> GetByUserDepartmentAllIncAsync(int departmentId, int categoryId, StatusType statusType)
        {
            return await _ticketDal.GetByUserDepartmentAllIncAsync(departmentId, categoryId, statusType);
        }
    }
}
