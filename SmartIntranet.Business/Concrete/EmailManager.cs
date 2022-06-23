using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class EmailManager : IEmailService
    {
        private readonly ISmtpEmailService _emailService;
        private readonly ITicketService _ticketService;

        public EmailManager(ISmtpEmailService emailService, ITicketService ticketService)
        {
            _emailService = emailService;
            _ticketService = ticketService;
        }

        public void TicketSendEmail(int ticketId,string ticketMessages, List<string> ToEmail)
        {
            var emailMessage = CreateEmailMessage(ticketId, ticketMessages, ToEmail);

            Send(emailMessage);
        }

        //public async Task TicketSendEmailAsync(int ticketId)
        //{
        //    var mailMessage = CreateEmailMessage(ticketId);

        //    await SendAsync(mailMessage);
        //}

        private MimeMessage CreateEmailMessage(int ticketId,string ticketMessage, List<string> ToEmail)
        {
            var smtpSettings = _emailService.Get();
            var ticket = _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply",smtpSettings.FromEmail));
            //emailMessage.To.Add(MailboxAddress.Parse("mahir.tahiroghlu@srgroupco.com"));
            //var toMail = 
            foreach (var item in ToEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }
            
            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", "<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + ticketMessage + "</a></h1>") };
           emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            var smtpSettings = _emailService.Get();
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(smtpSettings.FromEmail, smtpSettings.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        //private async Task SendAsync(MimeMessage mailMessage)
        //{
        //    var smtpSettings = _emailService.Get();
        //    using (var client = new SmtpClient())
        //    {
        //        try
        //        {
        //            await client.ConnectAsync(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls);
        //            client.AuthenticationMechanisms.Remove("XOAUTH2");
        //            await client.AuthenticateAsync(smtpSettings.UserName, smtpSettings.Password);

        //            await client.SendAsync(mailMessage);
        //        }
        //        catch
        //        {
        //            //log an error message or throw an exception, or both.
        //            throw;
        //        }
        //        finally
        //        {
        //            await client.DisconnectAsync(true);
        //            client.Dispose();
        //        }
        //    }
        //}
    }
}
