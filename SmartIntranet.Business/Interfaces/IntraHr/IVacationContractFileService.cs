using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IVacationContractFileService : IGenericService<VacationContractFile>
    {
        Task<List<VacationContractFile>> GetAllIncCompAsync();
        Task<List<VacationContractFile>> GetAllAsync(Expression<Func<VacationContractFile, bool>> filter);
        Task<List<VacationContractFile>> GetAllIncCompAsync(Expression<Func<VacationContractFile, bool>> filter);
    }
}
