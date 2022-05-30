using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class PersonalContractManager : GenericManager<PersonalContract>, IPersonalContractService
    {
        private readonly IGenericDal<PersonalContract> _genericDal;
        private readonly IPersonalContractDal _contractDal;

        public PersonalContractManager(IGenericDal<PersonalContract> genericDal, IPersonalContractDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<PersonalContract>> GetAllAsync(Expression<Func<PersonalContract, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<PersonalContract>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<PersonalContract>> GetAllIncCompAsync(Expression<Func<PersonalContract, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
