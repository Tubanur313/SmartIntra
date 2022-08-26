using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;

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

       public SMTPEmailSetting Get()
        {
            return _emailDal.Get();
        }
    }
}
