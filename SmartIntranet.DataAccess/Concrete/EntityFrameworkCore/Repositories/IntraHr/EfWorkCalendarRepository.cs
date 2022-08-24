using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkCalendarRepository : EfGenericRepository<WorkCalendar>, IWorkCalendarDal
    {
        public async Task<List<WorkCalendar>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.WorkCalendars.OrderByDescending(c => c.Number).ToListAsync();
        }

        public async Task<List<WorkCalendar>> GetAllIncCompAsync(Expression<Func<WorkCalendar, bool>> filter, int yearId, int graphId)
        {
            using var context = new IntranetContext();
            return await context.WorkCalendars.Include(x => x.WorkGraphic).ThenInclude(x=>x.NonWorkingYear).Where(x=> x.WorkGraphicId == graphId && x.NonWorkingYearId == yearId).Where(filter).OrderByDescending(c => c.Number).ToListAsync();

        }
    }

}
