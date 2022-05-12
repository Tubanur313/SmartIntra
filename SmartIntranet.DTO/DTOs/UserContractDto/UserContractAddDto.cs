using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.UserContractDto
{
    public class UserContractAddDto
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int? AppUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
