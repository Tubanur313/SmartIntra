using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Interfaces.Membership
{
    public interface IUserVacationRemainDal : IGenericDal<UserVacationRemain>
    {
        Task<List<UserVacationRemain>> GetAllIncCompAsync(); 
        Task<List<UserVacationRemain>> GetAllIncCompAsync(Expression<Func<UserVacationRemain, bool>> filter); 
    }
}
