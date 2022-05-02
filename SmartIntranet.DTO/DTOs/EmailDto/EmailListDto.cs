using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.EmailDto
{
    public class EmailListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; } = true;
        public string FromEmail { get; set; }
        public string BaseUrl { get; set; }

        public bool IsDefault { get; set; } = true;
    }
}
