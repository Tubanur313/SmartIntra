using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Business.Concrete.Intranet
{
    public class GradeManager : GenericManager<Grade>, IGradeService
    {
        private readonly IGenericDal<Grade> _genericDal;
        private readonly IGradeDal _gradeDal;

        public GradeManager(IGenericDal<Grade> genericDal, IGradeDal gradeDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _gradeDal = gradeDal;
        }
    }
}
