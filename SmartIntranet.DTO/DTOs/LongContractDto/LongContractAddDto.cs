using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.IntraHr;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.LongContractDto
{
    public class LongContractAddDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public IntranetUser User { get; set; }
        public virtual ICollection<LongContractFile> LongContractFiles { get; set; }
    }
}
