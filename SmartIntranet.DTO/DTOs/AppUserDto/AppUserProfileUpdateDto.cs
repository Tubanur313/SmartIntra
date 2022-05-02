using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserProfileUpdateDto
    {
        public AppUserProfileDto AppUserProfileDto { get; set; }
        public AppUserPassDto AppUserPassDto { get; set; }
        public AppUserImageDto AppUserImageDto { get; set; }

    }
}
