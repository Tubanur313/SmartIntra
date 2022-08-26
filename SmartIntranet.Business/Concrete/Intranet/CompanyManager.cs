using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class CompanyManager : GenericManager<Company>, ICompanyService
    {
        private readonly IGenericDal<Company> _genericDal;
        private readonly ICompanyDal _companyDal;

        public CompanyManager(IGenericDal<Company> genericDal, ICompanyDal companyDal) : base(genericDal)
        {
            _companyDal = companyDal;
            _genericDal = genericDal;
        }

        public async Task<List<Company>> GetAllAsync(Expression<Func<Company, bool>> filter)
        {
            return await _companyDal.GetAllAsync(filter);
        }
    }
}
