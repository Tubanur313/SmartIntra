using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class UserExperience : BaseEntity
    {
        public string Place { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ExperienceStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ExperienceEnd { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
    }
}
