using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Core.Entities.Enum;

namespace SmartIntranet.Entities.Concrete.Intranet.FAQ
{
    public class Faq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string File { get; set; }
        public FaqCategory FaqCategory { get; set; }
    }
}
