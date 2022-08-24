using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class UserContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public int AppUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
    }
}
