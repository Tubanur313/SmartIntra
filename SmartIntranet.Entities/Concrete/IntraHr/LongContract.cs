using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class LongContract : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public IntranetUser User { get; set; }
        public virtual ICollection<LongContractFile> LongContractFiles { get; set; }
    }
}
