using System;
using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete
{
    public class Entrance : BaseEntity
    {
        public string BrowInfo { get; set; }
        public string PcInfo { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
    }
}
