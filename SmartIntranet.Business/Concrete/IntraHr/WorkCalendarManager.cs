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
    public class WorkCalendarManager : GenericManager<WorkCalendar>, IWorkCalendarService
    {
        private readonly IGenericDal<WorkCalendar> _genericDal;
        private readonly IWorkCalendarDal _workCalendarDal;

        public WorkCalendarManager(IGenericDal<WorkCalendar> genericDal, IWorkCalendarDal workCalendarDal) : base(genericDal)
        {
            _workCalendarDal = workCalendarDal;
            _genericDal = genericDal;
        }

        public async Task<List<WorkCalendar>> GetAllAsync(Expression<Func<WorkCalendar, bool>> filter)
        {
            return await _workCalendarDal.GetAllAsync(filter);
        }

        public Task<List<WorkCalendar>> GetAllIncCompAsync()
        {
            return _workCalendarDal.GetAllIncCompAsync();
        }

        public Task<List<WorkCalendar>> GetAllIncCompAsync(Expression<Func<WorkCalendar, bool>> filter, int  yearId, int graphId)
        {
            return _workCalendarDal.GetAllIncCompAsync(filter, yearId, graphId);
        }
    }
}
