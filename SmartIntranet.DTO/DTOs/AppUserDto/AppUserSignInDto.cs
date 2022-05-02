using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserSignInDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string captcha { get; set; }
    }
}
