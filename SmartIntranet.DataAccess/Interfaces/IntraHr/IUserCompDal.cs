using SmartIntranet.Entities.Concrete.IntraHr;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IUserCompDal : IGenericDal<UserComp>
    {
        Task<List<UserComp>> GetAllIncAsync(int signInUserId);
        Task<List<UserComp>> GetAllIncUserAsync(int signInUserId);
        Task<List<UserComp>> GetAllIncUserWithFilterAsync(int signInUserId, int companyId, int departmentId, int positionId);
    }
}
