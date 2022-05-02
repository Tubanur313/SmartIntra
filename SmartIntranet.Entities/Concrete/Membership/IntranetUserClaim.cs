using Microsoft.AspNetCore.Identity;
using SmartIntranet.Core.Entities.Abstract;
using System;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class IntranetUserClaim: IdentityUserClaim<int>, IStatus, ICreatedByUser, IUpdateByUserId, IDeleteByUser
    {
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
