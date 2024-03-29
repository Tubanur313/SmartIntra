﻿using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITicketOrderDal : IGenericDal<TicketOrder>
    {
        Task<List<TicketOrder>> GetAllIncludeAsync();
        Task<List<TicketOrder>> GetAllIncludeAsync(int ticketId);
        Task<List<TicketOrder>> FindOrdersByTicketId(int Id);
    }
}
