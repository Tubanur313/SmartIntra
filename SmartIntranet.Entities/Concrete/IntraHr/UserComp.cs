using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

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
