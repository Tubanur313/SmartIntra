using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IWorkCalendarService : IGenericService<WorkCalendar>
    {
        Task<List<WorkCalendar>> GetAllIncCompAsync();
        Task<List<WorkCalendar>> GetAllAsync(Expression<Func<WorkCalendar, bool>> filter);
        Task<List<WorkCalendar>> GetAllIncCompAsync(Expression<Func<WorkCalendar, bool>> filter, int yearId, int graphId);
    }
}
