using SmartIntranet.Business.Interfaces.IntraTicket.TicketTripServices;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraTicket.TicketTripDals;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.Business.Concrete.IntraTicket.TicketTripManagers
{
    public class VacationLeaveManager : GenericManager<VacationLeave>, IVacationLeaveService
    {
        private readonly IGenericDal<VacationLeave> _genericDal;
        private readonly IVacationLeaveDal _vacationLeaveDal;
        public VacationLeaveManager(IGenericDal<VacationLeave> genericDal, IVacationLeaveDal vacationLeaveDal) : base(genericDal)
        {
            _vacationLeaveDal = vacationLeaveDal;
            _genericDal = genericDal;
        }
    }
}
