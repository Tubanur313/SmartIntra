using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IUserVacationRemainService : IGenericService<UserVacationRemain>
    {
        Task<List<UserVacationRemain>> GetAllIncCompAsync();
        Task<List<UserVacationRemain>> GetAllAsync(Expression<Func<UserVacationRemain, bool>> filter);
        Task<List<UserVacationRemain>> GetAllIncCompAsync(Expression<Func<UserVacationRemain, bool>> filter);
    }
}
