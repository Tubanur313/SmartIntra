using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IPersonalContractFileDal : IGenericDal<PersonalContractFile>
    {
        Task<List<PersonalContractFile>> GetAllIncCompAsync(); 
        Task<List<PersonalContractFile>> GetAllIncCompAsync(Expression<Func<PersonalContractFile, bool>> filter); 
    }
}
