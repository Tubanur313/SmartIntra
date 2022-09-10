using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Business.Interfaces
{
    public interface ISettingsService : IGenericService<Settings>
    {
        Settings Get();
    }
}
