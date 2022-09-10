using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface IPersonalContractFileDal : IGenericDal<PersonalContractFile>
    {
        Task<List<PersonalContractFile>> GetAllIncCompAsync(); 
        Task<List<PersonalContractFile>> GetAllIncCompAsync(Expression<Func<PersonalContractFile, bool>> filter); 
    }
}
