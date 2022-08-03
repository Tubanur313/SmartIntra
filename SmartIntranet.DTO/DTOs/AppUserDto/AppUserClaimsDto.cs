using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserClaimsDto
    {
        public IntranetUser User { get; set; }
        public IEnumerable<Tuple<IntranetRole, bool>> Roles { get; set; }
        public IEnumerable<Tuple<string, bool>> Claims { get; set; }
        public IEnumerable<Tuple<Company, bool>> Companies { get; set; }
        public string ClaimType { get; set; }
        public int? RoleId { get; set; }
        public int? CompanyId { get; set; }
    }
}
