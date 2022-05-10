using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class SmtpEmailManager : GenericManager<SMTPEmailSetting>, ISmtpEmailService
    {
        private readonly IGenericDal<SMTPEmailSetting> _genericDal;
        private readonly ISmtpEmailDal _emailDal;

        public SmtpEmailManager(IGenericDal<SMTPEmailSetting> genericDal, ISmtpEmailDal emailDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _emailDal = emailDal;
        }

        async Task<SMTPEmailSetting> ISmtpEmailService.GetAsync()
        {
            return await _emailDal.GetAsync();
        }
    }
}
