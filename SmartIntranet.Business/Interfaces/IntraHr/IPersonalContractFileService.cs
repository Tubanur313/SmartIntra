using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Interfaces.IntraHr
{
    public interface IPersonalContractFileService : IGenericService<PersonalContractFile>
    {
        Task<List<PersonalContractFile>> GetAllIncCompAsync();
        Task<List<PersonalContractFile>> GetAllAsync(Expression<Func<PersonalContractFile, bool>> filter);
        Task<List<PersonalContractFile>> GetAllIncCompAsync(Expression<Func<PersonalContractFile, bool>> filter);
    }
}
