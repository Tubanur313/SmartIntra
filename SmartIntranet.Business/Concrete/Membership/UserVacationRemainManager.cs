using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class UserVacationRemainManager : GenericManager<UserVacationRemain>, IUserVacationRemainService
    {
        private readonly IGenericDal<UserVacationRemain> _genericDal;
        private readonly IUserVacationRemainDal _clauseDal;

        public UserVacationRemainManager(IGenericDal<UserVacationRemain> genericDal, IUserVacationRemainDal clauseyDal) : base(genericDal)
        {
            _clauseDal = clauseyDal;
            _genericDal = genericDal;
        }

        public async Task<List<UserVacationRemain>> GetAllAsync(Expression<Func<UserVacationRemain, bool>> filter)
        {
            return await _clauseDal.GetAllAsync(filter);
        }

        public Task<List<UserVacationRemain>> GetAllIncCompAsync()
        {
            return _clauseDal.GetAllIncCompAsync();
        }

        public Task<List<UserVacationRemain>> GetAllIncCompAsync(Expression<Func<UserVacationRemain, bool>> filter)
        {
            return _clauseDal.GetAllIncCompAsync(filter);
        }
    }
}
