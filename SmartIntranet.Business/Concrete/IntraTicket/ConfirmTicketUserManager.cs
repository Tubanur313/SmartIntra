using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.IntraTicket
{
    public class ConfirmTicketUserManager : GenericManager<ConfirmTicketUser>, IConfirmTicketUserService
    {
        private readonly IGenericDal<ConfirmTicketUser> _genericDal;
        private readonly IConfirmTicketUserDal _confirmTicketUserDal;

        public ConfirmTicketUserManager(IGenericDal<ConfirmTicketUser> genericDal, 
            IConfirmTicketUserDal confirmTicketUserDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _confirmTicketUserDal = confirmTicketUserDal;
        }

        public async Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId)
        {
            return await _confirmTicketUserDal.MyConfirmNeedTicketsAsync(userId);
        }
        public async Task<List<ConfirmTicketUser>> MyConfirmNeedTicketsAsync(int userId, int categoryId, StatusType statusType)
        {
            return await _confirmTicketUserDal.MyConfirmNeedTicketsAsync(userId,categoryId, statusType);
        }

    }
}
