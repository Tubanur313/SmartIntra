using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class UserExperience : BaseEntity
    {
        public string Place { get; set; }
        public DateTime ExperienceStart { get; set; }
        public DateTime ExperienceEnd { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
    }
}
