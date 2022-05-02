using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
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
