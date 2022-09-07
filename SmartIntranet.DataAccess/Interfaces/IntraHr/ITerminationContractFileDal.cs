using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Interfaces.IntraHr
{
    public interface ITerminationContractFileDal : IGenericDal<TerminationContractFile>
    {
        Task<List<TerminationContractFile>> GetAllIncCompAsync(); 
        Task<List<TerminationContractFile>> GetAllIncCompAsync(Expression<Func<TerminationContractFile, bool>> filter); 
    }
}
