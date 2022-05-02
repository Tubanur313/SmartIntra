using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Concrete
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
