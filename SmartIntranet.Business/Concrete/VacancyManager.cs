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
    public class VacancyManager : GenericManager<Vacancy>, IVacancyService
    {
        private readonly IGenericDal<Vacancy> _genericDal;
        private readonly IVacancyDal _vacancyDal;

        public VacancyManager(IGenericDal<Vacancy> genericDal, IVacancyDal vacancyDal) : base(genericDal)
        {
            _vacancyDal = vacancyDal;
            _genericDal = genericDal;
        }

        public async Task<Vacancy> FindByIdAllIncludeAsync(int id)
        {
            return await _vacancyDal.FindByIdAllIncludeAsync(id);
        }

        public Vacancy FindByIdIncAsync(int id)
        {
            return _vacancyDal.FindByIdIncAsync(id);
        }

        public Task<List<Vacancy>> GetAllIncludeAsync(Expression<Func<Vacancy, bool>> filter)
        {
            return _vacancyDal.GetAllIncludeAsync(filter);
        }
    }
}
