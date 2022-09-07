using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IClauseDal : IGenericDal<Clause>
    {
        Task<List<Clause>> GetAllIncCompAsync(); 
        Task<List<Clause>> GetAllIncCompAsync(Expression<Func<Clause, bool>> filter); 
    }
}
