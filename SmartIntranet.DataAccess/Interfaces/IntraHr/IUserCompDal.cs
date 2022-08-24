using SmartIntranet.Entities.Concrete.IntraHr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IUserCompDal : IGenericDal<UserComp>
    {
        Task<List<UserComp>> GetAllIncAsync(int signInUserId);
        Task<UserComp> FirstOrDefault(int signInUserId);
    }
}
