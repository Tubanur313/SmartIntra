using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Business.Concrete.Intranet
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
            _genericDal = genericDal;
        }

        public async Task<List<Category>> GetAllSortedByIdAsync()
        {
            return await _genericDal.GetAllAsync(I => I.Id);
        }
    }
}
