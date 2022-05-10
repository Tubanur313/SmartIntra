using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraTicket
{
    public class SMTPEmailSetting : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; } 
        public string FromEmail { get; set; }
        public string BaseUrl { get; set; }

        public bool IsDefault { get; set; } 
    }
}
