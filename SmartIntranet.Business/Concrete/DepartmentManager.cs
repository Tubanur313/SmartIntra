using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class DepartmentManager : GenericManager<Department>, IDepartmentService
    {
        private readonly IGenericDal<Department> _genericDal;
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IGenericDal<Department> genericDal, IDepartmentDal departmentDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _departmentDal = departmentDal;
        }

        public Task<List<Department>> GetAllIncludeAsync()
        {
            return _departmentDal.GetAllIncludeAsync();
        }
    }
}
