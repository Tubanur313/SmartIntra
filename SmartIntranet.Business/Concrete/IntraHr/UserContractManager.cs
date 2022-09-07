using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Membership;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class UserContractManager : GenericManager<UserContractFile>, IUserContractService
    {
        private readonly IGenericDal<UserContractFile> _genericDal;
        private readonly IUserContractFileDal _userContractFileDal;

        public UserContractManager(IGenericDal<UserContractFile> genericDal, IUserContractFileDal userContractFileDal) : base(genericDal)
        {
            _userContractFileDal = userContractFileDal;
            _genericDal = genericDal;
        }

        public async Task<List<UserContractFile>> GetContractsByActiveUserIdAsync(int id)
        {
            return await _userContractFileDal.GetContractsByActiveUserIdAsync(id);
        }
    }
}
