using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete.Inventary
{
    public class StockDiscuss : BaseEntity
    {
        public string Content { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
