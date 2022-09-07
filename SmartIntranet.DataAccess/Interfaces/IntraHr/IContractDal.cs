using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IContractDal : IGenericDal<Contract>
    {
        Task<List<Contract>> GetAllIncCompAsync(); 
        Task<List<Contract>> GetAllIncCompAsync(Expression<Func<Contract, bool>> filter);
        Task<List<Contract>> GetAllIncCompAsync(int companyId, int departmentId, int positionId, string Interval);
        Task<List<Contract>> GetAllIncCompAsync(int? compIdOfUser);
    }
}
