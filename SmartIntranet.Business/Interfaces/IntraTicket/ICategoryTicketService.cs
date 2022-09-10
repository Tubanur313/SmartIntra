﻿using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces.IntraTicket
{
    public interface ICategoryTicketService : IGenericService<CategoryTicket>
    {
        Task<List<CategoryTicket>> GetAllIncludeAsync(bool asnotrack=false);
        Task<CategoryTicket> GetIncludeAsync(int id);
    }
}
