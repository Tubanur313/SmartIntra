using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<IntranetUser>
    {
        Task<List<IntranetUser>> GetAllIncludeAsync();
        Task<IntranetUser> FindByUserAllInc(int id);
        Task<IntranetUser> FindUserByEmail(string email);
        Task<IntranetUser> FindUserPosWithId(int id);
        Task<bool> IsExistEmail(string email);
        Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter);

    }
}
