using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class UserComp : BaseEntity
    {
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
