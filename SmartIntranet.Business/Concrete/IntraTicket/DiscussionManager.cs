using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.IntraTicket
{
    public class DiscussionManager : GenericManager<Discussion>, IDiscussionService
    {
        private readonly IGenericDal<Discussion> _genericDal;
        private readonly IDiscussionDal _discussionDal;

        public DiscussionManager(IGenericDal<Discussion> genericDal, IDiscussionDal discussionDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _discussionDal = discussionDal;
        }
        public Task<List<Discussion>> GetAllByTicketAsync(int ticketId)
        {
            return _discussionDal.GetAllByTicketAsync(ticketId);
        }
        public Task<Discussion> GetAllIncludeAsync(int id)
        {
            return _discussionDal.GetAllIncludeAsync(id);
        }
    }
}
