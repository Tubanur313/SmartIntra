using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Interfaces.Intranet;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Business.Concrete.Intranet
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
