using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Interfaces.Membership
{
    public interface IAppUserDal : IGenericDal<IntranetUser>
    {
        Task<List<IntranetUser>> GetAllIncludeAsync(bool asnotrack = false);
        Task<IntranetUser> FindByUserAllInc(int id);
        Task<IntranetUser> FindUserByEmail(string email);
        Task<IntranetUser> FindUserPosWithId(int id);
        Task<bool> IsExistEmail(string email);
        Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter, bool asnotrack = false);
        Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int compId, int departId, int positId, bool asnotrack = false);
        Task<List<IntranetUser>> GetAllIncUserAsync(int? userCompId, bool asnotrack = false);
        Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int? userCompId, bool asnotrack = false);
    }
}
