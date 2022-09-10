using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IUserContractService : IGenericService<UserContractFile>
    {
        Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int id);
    }
}
