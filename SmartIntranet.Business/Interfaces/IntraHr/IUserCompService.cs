using SmartIntranet.Entities.Concrete.IntraHr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IUserCompService : IGenericService<UserComp>
    {
        Task<List<UserComp>> GetAllIncAsync(int signInUserId);
    }
}
