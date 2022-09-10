using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Interfaces
{
    public interface ISettingsDal : IGenericDal<Settings>
    {
        Settings Get();
    }
}
