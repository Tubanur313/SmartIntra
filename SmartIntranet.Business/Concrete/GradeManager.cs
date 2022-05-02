using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class GradeManager : GenericManager<Grade>, IGradeService
    {
        private readonly IGenericDal<Grade> _genericDal;
        private readonly IGradeDal _gradeDal;

        public GradeManager(IGenericDal<Grade> genericDal, IGradeDal gradeDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _gradeDal = gradeDal;
        }

        public async Task<List<Grade>> GetAllAsync(Expression<Func<Grade, bool>> filter)
        {
            return await _gradeDal.GetAllAsync(filter);
        }
    }
}
