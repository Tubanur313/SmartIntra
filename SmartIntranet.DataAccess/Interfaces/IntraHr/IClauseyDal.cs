using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IClauseDal : IGenericDal<Clause>
    {
        Task<List<Clause>> GetAllIncCompAsync(); 
        Task<List<Clause>> GetAllIncCompAsync(Expression<Func<Clause, bool>> filter); 
    }
}
