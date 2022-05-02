using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class AppUserManager : GenericManager<IntranetUser>, IAppUserService
    {
        private readonly IGenericDal<IntranetUser> _genericDal;
        private readonly IAppUserDal _userDal;

        public AppUserManager(IGenericDal<IntranetUser> genericDal, IAppUserDal userDal) : base(genericDal)
        {
            _userDal = userDal;
            _genericDal = genericDal;
        }
        public async Task<IntranetUser> FindByUserAllInc(int id)
        {
            return await _userDal.FindByUserAllInc(id);
        }

        public async Task<IntranetUser> FindUserByEmail(string email)
        {
            return await _userDal.FindUserByEmail(email);
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync()
        {

            return await _userDal.GetAllIncludeAsync();
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter)
        {
            return await _userDal.GetAllIncludeAsync(filter);
        }

        public async Task<bool> IsExistEmail(string email)
        {
            return await _userDal.IsExistEmail(email);
        }
    }
}
