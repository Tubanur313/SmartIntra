using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.Membership
{
    public interface IUserContractService : IGenericService<UserContractFile>
    {
        Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int id);
    }
}
