using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Membership;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Business.Concrete.Membership
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

        public async Task<IntranetUser> FindUserPosWithId(int id)
        {
            return await _userDal.FindUserPosWithId(id);
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(bool asnotrack = false)
        {

            return await _userDal.GetAllIncludeAsync(asnotrack);
        }

        public async Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter, bool asnotrack = false)
        {
            return await _userDal.GetAllIncludeAsync(filter, asnotrack);
        }

        public async Task<List<IntranetUser>> GetAllIncUserAsync(int? userCompId, bool asnotrack = false)
        {
            return await _userDal.GetAllIncUserAsync(userCompId, asnotrack);

        }

        public async Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int compId, int departId, int positId, bool asnotrack = false)
        {
            return await _userDal.GetAllIncUserWithFilterAsync(compId, departId, positId);
        }

        public async Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int? userCompId, bool asnotrack = false)
        {
            return await _userDal.GetAllIncUserWithFilterAsync(userCompId, asnotrack);
        }

        public async Task<bool> IsExistEmail(string email)
        {
            return await _userDal.IsExistEmail(email);
        }
    }
}
