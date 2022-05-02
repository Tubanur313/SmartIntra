using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class TicketCheckListManager : GenericManager<TicketCheckList>, ITicketCheckListService
    {
        private readonly IGenericDal<TicketCheckList> _genericDal;
        private readonly ITicketCheckListDal _ticketCheckListDal;

        public TicketCheckListManager(IGenericDal<TicketCheckList> genericDal, ITicketCheckListDal ticketCheckListDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _ticketCheckListDal = ticketCheckListDal;
        }

        public async Task<List<TicketCheckList>> FindByIdAllIncAsync(int id)
        {
          return  await _ticketCheckListDal.FindByIdAllIncAsync(id);
        }

        public async Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId)
        {
            return await _ticketCheckListDal.FindByIdChecklistIncAsync(ticketId);
        }
    }
}
