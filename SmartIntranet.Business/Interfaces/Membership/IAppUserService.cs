using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IAppUserService : IGenericService<IntranetUser>
    {
        Task<List<IntranetUser>> GetAllIncludeAsync();
        Task<IntranetUser> FindByUserAllInc(int id);
        Task<IntranetUser> FindUserByEmail(string email);
        Task<IntranetUser> FindUserPosWithId(int id);
        Task<bool> IsExistEmail(string email);
        Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter);
        Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int compId, int departId, int positId);
        Task<List<IntranetUser>> GetAllIncUserAsync(int? userCompId);
        Task<List<IntranetUser>> GetAllIncUserWithFilterAsync(int? userCompId);
    }
}
