using SmartIntranet.Business.Interfaces.Intranet.FAQ;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Intranet.FAQ;
using SmartIntranet.Entities.Concrete.Intranet.FAQ;

namespace SmartIntranet.Business.Concrete.Intranet.FAQ
{
    public class FaqManager : GenericManager<Faq>, IFaqService
    {
        private readonly IGenericDal<Faq> _genericDal;
        private readonly IFaqDal _faqDal;

        public FaqManager(IGenericDal<Faq> genericDal, IFaqDal faqDal) : base(genericDal)
        {
            _faqDal = faqDal;
            _genericDal = genericDal;
        }
    }
}
