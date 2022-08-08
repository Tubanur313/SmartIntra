using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class UserCompManager : GenericManager<UserComp>, IUserCompService
    {
        private readonly IGenericDal<UserComp> _genericDal;
        private readonly IUserCompDal _userCompDal;

        public UserCompManager(IGenericDal<UserComp> genericDal, IUserCompDal userCompDal) : base(genericDal)
        {
            _userCompDal = userCompDal;
            _genericDal = genericDal;
        }

        public Task<UserComp> FirstOrDefault(int signInUserId)
        {
            return _userCompDal.FirstOrDefault(signInUserId);
        }

        public Task<List<UserComp>> GetAllIncAsync(int signInUserId)
        {
            return _userCompDal.GetAllIncAsync(signInUserId);
        }

    }
}
