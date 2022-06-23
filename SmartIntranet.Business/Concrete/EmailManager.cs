using MailKit.Net.Smtp;
using MimeKit;
using SmartIntranet.Business.Email;
using SmartIntranet.Business.Interfaces;
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

        public EmailManager(ISmtpEmailService emailService)
        {
            _emailService = emailService;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var smtpSettings =_emailService.Get();
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(smtpSettings.FromEmail));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

            //if (message.Attachments != null && message.Attachments.Any())
            //{
            //    byte[] fileBytes;
            //    foreach (var attachment in message.Attachments)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            attachment.CopyTo(ms);
            //            fileBytes = ms.ToArray();
            //        }

            //        bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            //    }
            //}

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
                    client.Connect(smtpSettings.Host, smtpSettings.Port, smtpSettings.IsSSL);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(smtpSettings.UserName, smtpSettings.Password);

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

        private async Task SendAsync(MimeMessage mailMessage)
        {
            var smtpSettings = _emailService.Get();
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(smtpSettings.Host, smtpSettings.Port, smtpSettings.IsSSL);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(smtpSettings.UserName, smtpSettings.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
