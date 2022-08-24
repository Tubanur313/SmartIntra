using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IUserVacationRemainDal : IGenericDal<UserVacationRemain>
    {
        Task<List<UserVacationRemain>> GetAllIncCompAsync(); 
        Task<List<UserVacationRemain>> GetAllIncCompAsync(Expression<Func<UserVacationRemain, bool>> filter); 
    }
}
