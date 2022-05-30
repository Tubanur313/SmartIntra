using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.PersonalContractDto
{
    public class PersonalContractListDto
    {
        public int Id { get; set; }
        public string CommandNumber { get; set; }
        public string Type { get; set; }
        public int? PositionId { get; set; }
        public double? Salary { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
