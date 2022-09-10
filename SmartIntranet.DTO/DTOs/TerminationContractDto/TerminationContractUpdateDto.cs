using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Entities.Concrete.IntraHr;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime TerminationDate { get; set; }
        public string CommandNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CommandDate { get; set; }
        public string ReductionNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? ReductionDate { get; set; }
        public int UserId { get; set; }
        public int TerminationItemId { get; set; }
        public TerminationItem TerminationItem { get; set; }
        public IntranetUser User { get; set; }

        public virtual ICollection<TerminationContractFile> TerminationContractFiles { get; set; }

    }
}
