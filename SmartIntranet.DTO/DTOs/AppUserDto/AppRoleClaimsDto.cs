using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppRoleClaimsDto
    {
        public IntranetRole Role { get; set; }
        public IEnumerable<Tuple<string, bool>> Claims { get; set; }
        public string ClaimType { get; set; }
        public int RoleId { get; set; }
    }
}
