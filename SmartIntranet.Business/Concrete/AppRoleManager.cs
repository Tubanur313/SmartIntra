using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Business.Concrete
{
    public class AppRoleManager : GenericManager<IntranetRole>, IAppRoleService
    {
        private readonly IGenericDal<IntranetRole> _genericDal;
        private readonly IAppRoleDal _roleDal;

        public AppRoleManager(IGenericDal<IntranetRole> genericDal, IAppRoleDal roleDal) : base(genericDal)
        {
            _roleDal = roleDal;
            _genericDal = genericDal;
        }
    }
}
