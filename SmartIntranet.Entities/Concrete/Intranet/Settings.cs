using Microsoft.AspNetCore.Http;
using SmartIntranet.Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartIntranet.Entities.Concrete.Intranet
{
    public class Settings : BaseEntity
    {
        public string UserName { get; set; }
        public string TicketMail { get; set; }
        public string TicketPassword { get; set; }
        public string TicketHost { get; set; }
        public int TicketPort { get; set; }   
        public string HrMail { get; set; }
        public string HrPassword { get; set; }
        public string HrHost { get; set; }
        public int HrPort { get; set; }
        public string BaseUrl { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyName { get; set; }
        public string CompanySite { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
    }
}
