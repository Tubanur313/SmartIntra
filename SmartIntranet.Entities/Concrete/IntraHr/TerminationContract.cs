using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class TerminationContract : BaseEntity
    {
        public string Description { get; set; } // emrin esasi
        public string Content { get; set; } // emrin mezmunu
        public int RemainVacationCount { get; set; } // emrin mezmunu
        public bool IsReduction { get; set; }
        public bool IsAgree { get; set; }
        public DateTime TerminationDate { get; set; }
        public string CommandNumber { get; set; }
        public DateTime CommandDate { get; set; }
        public string ReductionNumber { get; set; }
        public DateTime? ReductionDate { get; set; }
        public int UserId { get; set; }
        public int TerminationItemId { get; set; }
        public TerminationItem TerminationItem { get; set; }
        public IntranetUser User { get; set; }

        public virtual ICollection<TerminationContractFile> TerminationContractFiles { get; set; }
    }
}
