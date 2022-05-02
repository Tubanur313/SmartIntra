using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class UserContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public int AppUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
    }
}
