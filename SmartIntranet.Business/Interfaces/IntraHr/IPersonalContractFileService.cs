using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IPersonalContractFileService : IGenericService<PersonalContractFile>
    {
        Task<List<PersonalContractFile>> GetAllIncCompAsync();
        Task<List<PersonalContractFile>> GetAllAsync(Expression<Func<PersonalContractFile, bool>> filter);
        Task<List<PersonalContractFile>> GetAllIncCompAsync(Expression<Func<PersonalContractFile, bool>> filter);
    }
}
