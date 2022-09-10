using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class ReportEmployeeManager : GenericManager<ReportEmployee>, IReportEmployeeService
    {
        private readonly IGenericDal<ReportEmployee> _genericDal;
        private readonly IReportEmployeeDal _contractDal;

        public ReportEmployeeManager(IGenericDal<ReportEmployee> genericDal, IReportEmployeeDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<ReportEmployee>> GetAllAsync(Expression<Func<ReportEmployee, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<ReportEmployee>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<ReportEmployee>> GetAllIncCompAsync(Expression<Func<ReportEmployee, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
