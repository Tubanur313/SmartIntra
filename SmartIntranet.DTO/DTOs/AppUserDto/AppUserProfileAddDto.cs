using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserProfileAddDto
    {
        public int Id { get; set; }
        //public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
        public string Address { get; set; }

    }
}
