using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Entities.Concrete
{
    public class Grade:BaseEntity
    {
        public string GradeName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }
    }
}
