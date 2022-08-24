using SmartIntranet.Entities.Concrete.Membership;
using System;

namespace SmartIntranet.DTO.DTOs.UserContractDto
{
    public class UserContractListDto
    {
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public string FilePath { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
