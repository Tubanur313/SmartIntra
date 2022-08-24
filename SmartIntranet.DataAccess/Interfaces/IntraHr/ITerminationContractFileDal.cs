using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ITerminationContractFileDal : IGenericDal<TerminationContractFile>
    {
        Task<List<TerminationContractFile>> GetAllIncCompAsync(); 
        Task<List<TerminationContractFile>> GetAllIncCompAsync(Expression<Func<TerminationContractFile, bool>> filter); 
    }
}
