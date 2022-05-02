using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITicketCheckListDal : IGenericDal<TicketCheckList>
    {
        Task<List<TicketCheckList>> FindByIdAllIncAsync(int id);
        Task<List<TicketCheckList>> FindByIdChecklistIncAsync(int ticketId);
    }
}
