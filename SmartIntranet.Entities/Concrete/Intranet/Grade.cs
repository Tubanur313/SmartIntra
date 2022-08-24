using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete.Intranet
{
    public class Grade:BaseEntity
    {
        public string GradeName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }
    }
}
