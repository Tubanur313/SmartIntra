using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class PersonalContractFileManager : GenericManager<PersonalContractFile>, IPersonalContractFileService
    {
        private readonly IGenericDal<PersonalContractFile> _genericDal;
        private readonly IPersonalContractFileDal _contractDal;

        public PersonalContractFileManager(IGenericDal<PersonalContractFile> genericDal, IPersonalContractFileDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<PersonalContractFile>> GetAllAsync(Expression<Func<PersonalContractFile, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<PersonalContractFile>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<PersonalContractFile>> GetAllIncCompAsync(Expression<Func<PersonalContractFile, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
