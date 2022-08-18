using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.TerminationContractDto
{
    public class TerminationContractUpdateDto
    {
        public int Id { get; set; }
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
