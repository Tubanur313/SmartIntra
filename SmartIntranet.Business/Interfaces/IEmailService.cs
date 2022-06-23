using SmartIntranet.Business.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
