using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IVacationContractFileDal : IGenericDal<VacationContractFile>
    {
        Task<List<VacationContractFile>> GetAllIncCompAsync(); 
        Task<List<VacationContractFile>> GetAllIncCompAsync(Expression<Func<VacationContractFile, bool>> filter); 
    }
}
