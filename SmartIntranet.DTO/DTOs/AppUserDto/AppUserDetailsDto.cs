using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return FirstName+LastName + " / " + Company + " / " + Department + " / "+ Position;
        }
    }
}
