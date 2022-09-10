using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Concrete.IntraTicket
{
    public class EntranceManager : GenericManager<Entrance>, IEntranceService
    {
        private readonly IGenericDal<Entrance> _genericDal;
        private readonly IEntranceDal _entranceDal;

        public EntranceManager(IGenericDal<Entrance> genericDal, IEntranceDal entranceDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _entranceDal = entranceDal;
        }

    }
}
