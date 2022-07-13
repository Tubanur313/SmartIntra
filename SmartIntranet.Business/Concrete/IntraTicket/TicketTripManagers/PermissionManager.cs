using SmartIntranet.Business.Interfaces.IntraTicket.TicketTripServices;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraTicket.TicketTripDals;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.Business.Concrete.IntraTicket.TicketTripManagers
{
    public class PermissionManager : GenericManager<Permission>, IPermissionService
    {
        private readonly IGenericDal<Permission> _genericDal;
        private readonly IPermissionDal _permissionDal;
        public PermissionManager(IGenericDal<Permission> genericDal, IPermissionDal permissionDal) : base(genericDal)
        {
            _permissionDal = permissionDal;
            _genericDal = genericDal;
        }
    }
}
