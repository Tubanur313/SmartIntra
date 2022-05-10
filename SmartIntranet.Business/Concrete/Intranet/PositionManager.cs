using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Business.Interfaces.Intranet;

namespace SmartIntranet.Business.Concrete.Intranet
{
    public class PositionManager : GenericManager<Position>, IPositionService
    {
        private readonly IGenericDal<Position> _genericDal;
        private readonly IPositionDal _positionDal;

        public PositionManager(IGenericDal<Position> genericDal, IPositionDal positionDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _positionDal = positionDal;
        }

        public async Task<List<Position>> GetAllIncludeAsync()
        {
            return await _positionDal.GetAllIncludeAsync();
        }
    }
}
