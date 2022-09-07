using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.ContractDto
{
    public class ContractListDto
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
        public string ContractKey { get; set; }
        public DateTime? ContractStart { get; set; }
        public DateTime? CommandDate { get; set; }
        public string ContractNumber { get; set; }
        public string CommandNumber { get; set; }
        public string FullName { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<BusinessTripUser> BusinessTripUsers { get; set; }
    }
}
