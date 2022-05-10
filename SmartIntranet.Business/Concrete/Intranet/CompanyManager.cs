using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Business.Interfaces.Intranet;

namespace SmartIntranet.Business.Concrete.Intranet
{
    public class CompanyManager : GenericManager<Company>, ICompanyService
    {
        private readonly IGenericDal<Company> _genericDal;
        private readonly ICompanyDal _companyDal;

        public CompanyManager(IGenericDal<Company> genericDal, ICompanyDal companyDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _companyDal = companyDal;
        }

    }
}
