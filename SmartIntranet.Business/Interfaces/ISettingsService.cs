using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Interfaces
{
    public interface ISettingsService : IGenericService<Settings>
    {
        Settings Get();
    }
}
