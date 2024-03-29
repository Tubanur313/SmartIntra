﻿using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IContractDal : IGenericDal<Contract>
    {
        Task<List<Contract>> GetAllIncCompAsync(); 
        Task<List<Contract>> GetAllIncCompAsync(Expression<Func<Contract, bool>> filter); 
    }
}
