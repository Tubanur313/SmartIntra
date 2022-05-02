using SmartIntranet.Entities.Concrete;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface IDiscussionDal : IGenericDal<Discussion>
    {
        Task<Discussion> GetAllIncludeAsync(int id);
    }
}
