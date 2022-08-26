using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IWorkCalendarDal : IGenericDal<WorkCalendar>
    {
        Task<List<WorkCalendar>> GetAllIncCompAsync(); 
        Task<List<WorkCalendar>> GetAllIncCompAsync(Expression<Func<WorkCalendar, bool>> filter, int yearId, int graphId); 
    }
}
