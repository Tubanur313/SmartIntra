using SmartIntranet.Core.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class UserExperience : BaseEntity
    {
        public string Place { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExperienceStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExperienceEnd { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
    }
}
