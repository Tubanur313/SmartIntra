using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.ValidationRules.FluentValidation;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Concrete
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
