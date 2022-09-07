using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DataAccess.Interfaces.Membership
{
    public interface IUserContractFileDal : IGenericDal<UserContractFile>
    {
        Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int Id);
    }
}
