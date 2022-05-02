using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Business.Interfaces
{
    public interface IAppUserService : IGenericService<IntranetUser>
    {
        Task<List<IntranetUser>> GetAllIncludeAsync();
        Task<IntranetUser> FindByUserAllInc(int id);
        Task<IntranetUser> FindUserByEmail(string email);
        Task<bool> IsExistEmail(string email);
        Task<List<IntranetUser>> GetAllIncludeAsync(Expression<Func<IntranetUser, bool>> filter);
    }
}
