using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.Business.Concrete
{
    public class SettingsManager : GenericManager<Settings>, ISettingsService
    {
        private readonly IGenericDal<Settings> _genericDal;
        private readonly ISettingsDal _settingsDal;

        public SettingsManager(IGenericDal<Settings> genericDal, ISettingsDal settingsDal) : base(genericDal)
        {
            _settingsDal = settingsDal;
            _genericDal = genericDal;
        }

        public Settings Get()
        {
            return _settingsDal.Get();
        }
    }
}
