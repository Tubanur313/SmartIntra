using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IVacationContractFileDal : IGenericDal<VacationContractFile>
    {
        Task<List<VacationContractFile>> GetAllIncCompAsync(); 
        Task<List<VacationContractFile>> GetAllIncCompAsync(Expression<Func<VacationContractFile, bool>> filter); 
    }
}
