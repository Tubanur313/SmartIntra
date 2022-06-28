using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Core.Extensions;
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

        public async void TicketSendEmail(int ticketId, TicketChangeType type,string UserFullName)
        {
            MimeMessage emailMessage = new MimeMessage();
            if (type == TicketChangeType.TicketAdd)
            {
                emailMessage = await TicketAddEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketUpdate)
            {
                emailMessage = await TicketUpdateEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketStatus)
            {
                emailMessage = await TicketStatusEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketCategory)
            {
                emailMessage = await TicketCategoryEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketChecklist)
            {
                emailMessage = await TicketChecklistEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketPriority)
            {
                emailMessage = await TicketPriorityEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketDiscuss)
            {
                emailMessage = await TicketDiscussEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketImage)
            {
                emailMessage = await TicketImageEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketWatcher)
            {
                emailMessage = await TicketWatcherEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.ConfirmUser)
            {
                emailMessage = await TicketConfirmUserEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.ConfirmUserAdd)
            {
                emailMessage = await TicketConfirmAddEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.ConfirmTicket)
            {
                emailMessage = await TicketConfirmEmailMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketSupportRedirect)
            {
                emailMessage = await TicketRedirectEmailMessage(ticketId, UserFullName);
            }
            Send(emailMessage);
        }


        private async Task<MimeMessage> TicketAddEmailMessage(int ticketId,string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();
            if (ticket.Watchers != null)
            {
                foreach (var item in ticket.Watchers)
                {
                    toEmail.Add(item.IntranetUser.Email);

                }
            }
            if (ticket.ConfirmTicketUsers != null)
            {
                foreach (var item in ticket.ConfirmTicketUsers)
                {
                    toEmail.Add(item.IntranetUser.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketAdd.GetDisplayName() + "</a></h1> " +
                        "<p><strong>" + "Taskı Açan : </strong>" + UserFullName + "</p>" ) };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketUpdateEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();
            
            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketUpdate.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketStatusEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();
            if (ticket.Watchers != null)
            {
                foreach (var item in ticket.Watchers)
                {
                    toEmail.Add(item.IntranetUser.Email);

                }
            }
            if (ticket.ConfirmTicketUsers != null)
            {
                foreach (var item in ticket.ConfirmTicketUsers)
                {
                    toEmail.Add(item.IntranetUser.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketStatus.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketCategoryEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketCategory.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketChecklistEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketChecklist.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketPriorityEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketPriority.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketDiscussEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketDiscuss.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketImageEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketImage.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketWatcherEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketWatcher.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketConfirmUserEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.ConfirmUser.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketConfirmAddEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.ConfirmUserAdd.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketConfirmEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.ConfirmTicket.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketRedirectEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Supporter != null)
            {
                toEmail.Add(ticket.Supporter.Email);

            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.FromEmail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketSupportRedirect.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>") };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async void Send(MimeMessage mailMessage)
        {

            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            using (var client = new SmtpClient())
            {
                try
                {
                   await client.ConnectAsync(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                   await client.AuthenticateAsync(smtpSettings.FromEmail, smtpSettings.Password);

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
