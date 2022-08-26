using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IUserContractFileDal : IGenericDal<UserContractFile>
    {
        Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int Id);
    }
}
