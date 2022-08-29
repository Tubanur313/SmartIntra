using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ISettingsDal : IGenericDal<Settings>
    {
        Settings Get();
    }
}
