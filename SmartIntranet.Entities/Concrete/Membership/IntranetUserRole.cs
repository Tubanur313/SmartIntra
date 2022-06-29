using SmartIntranet.Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class IntranetUserRole:IdentityUserRole<int>
    {
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
