using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserInfoDto
    {
        public int Id { get; set; }

        public string Picture { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
    }
}
