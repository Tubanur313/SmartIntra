using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.AcroFields;

namespace SmartIntranet.Business.Concrete
{
    public class EmailManager : IEmailService
    {
        private readonly ISettingsService _settingsService;
        private readonly ITicketService _ticketService;

        public EmailManager( ITicketService ticketService, ISettingsService settingsService)
        {
            _ticketService = ticketService;
            _settingsService = settingsService;
        }

        public async void TicketSendEmail(int ticketId, TicketChangeType type, string UserFullName)
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
            if (type == TicketChangeType.TicketOrderUpdate)
            {
                emailMessage = await TicketOrderUpdateMessage(ticketId, UserFullName);
            }
            if (type == TicketChangeType.TicketOrderFileUpdate)
            {
                emailMessage = await TicketOrderFileUpdateMessage(ticketId, UserFullName);
            }
            Send(emailMessage);
        }

        private async Task<MimeMessage> TicketOrderFileUpdateMessage(int ticketId, string UserFullName)
        {
            //var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            //string watchers = string.Empty;
            //string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            //if (ticket.Watchers != null)
            //{
            //    foreach (var item in ticket.Watchers)
            //    {
            //        toEmail.Add(item.IntranetUser.Email);

            //    }
            //}
            //if (ticket.ConfirmTicketUsers != null)
            //{
            //    foreach (var item in ticket.ConfirmTicketUsers)
            //    {
            //        toEmail.Add(item.IntranetUser.Email);
            //    }
            //}
            if(ticket.Employee !=null)
            {
                if(ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketOrderFileUpdate.GetDisplayName() + "</a></h1> " +
                        "<p><strong>" + "Sifariş Faylında Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketOrderUpdateMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            //string watchers = string.Empty;
            //string confirmers = string.Empty;
            List<string> toEmail = new List<string>();
            //if (ticket.Watchers != null)
            //{
            //    foreach (var item in ticket.Watchers)
            //    {
            //        toEmail.Add(item.IntranetUser.Email);

            //    }
            //}
            //if (ticket.ConfirmTicketUsers != null)
            //{
            //    foreach (var item in ticket.ConfirmTicketUsers)
            //    {
            //        toEmail.Add(item.IntranetUser.Email);
            //    }
            //}
            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketOrderUpdate.GetDisplayName() + "</a></h1> " +
                        "<p><strong>" + "Sifarişdə Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        
        private async Task<MimeMessage> TicketAddEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
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
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketAdd.GetDisplayName() + "</a></h1> " +
                        "<p><strong>" + "Taskı Açan : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketUpdateEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketUpdate.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketStatusEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
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
            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketStatus.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketCategoryEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketCategory.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketChecklistEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketChecklist.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketPriorityEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketPriority.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketDiscussEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketDiscuss.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketImageEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketImage.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketWatcherEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketWatcher.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketConfirmUserEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.ConfirmUser.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketConfirmAddEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.ConfirmUserAdd.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketConfirmEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.ConfirmTicket.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<MimeMessage> TicketRedirectEmailMessage(int ticketId, string UserFullName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMail(ticketId);
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticketId;

            string watchers = string.Empty;
            string confirmers = string.Empty;
            List<string> toEmail = new List<string>();

            if (ticket.Employee != null)
            {
                if (ticket.Employee.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Employee.Email);
                }
            }
            if (ticket.Supporter != null)
            {
                if (ticket.Supporter.Fullname != UserFullName)
                {
                    toEmail.Add(ticket.Supporter.Email);
                }


            }
            else
            {
                toEmail.Add(smtpSettings.UserName);
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.TicketMail));
            foreach (var item in toEmail)
            {
                emailMessage.To.Add(MailboxAddress.Parse(item));
            }

            emailMessage.Subject = "No-Reply";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h1><a href ='" + callBackUrl + "'>" + "#" + ticketId + TicketChangeType.TicketSupportRedirect.GetDisplayName() + "</a></h1>" +
                        "<p><strong>" + "Dəyişiklik Edən : </strong>" + UserFullName + "</p>")
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async void Send(MimeMessage mailMessage)
        {

            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(smtpSettings.TicketHost, smtpSettings.TicketPort, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(smtpSettings.TicketMail, smtpSettings.TicketPassword);

                await client.SendAsync(mailMessage);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }        
        private async void HrSend(MimeMessage mailMessage)
        {

            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(smtpSettings.HrHost, smtpSettings.HrPort, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(smtpSettings.HrMail, smtpSettings.HrPassword);

                await client.SendAsync(mailMessage);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }

        public async void  ContractSendEmail(string userFullName, string company, string department, string position, string userProfile)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.HrMail));
            emailMessage.To.Add(MailboxAddress.Parse("ilkin.nazarli@srgroupco.com"));

            emailMessage.Subject = "Yeni Əməkdaş";
            var fullpath = string.Join("\\", System.IO.Path
                .GetFullPath(userProfile).Split("\\").SkipLast(1).ToArray());
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<p>Hörmətli əməkdaşlar,</p>\r\n\r\n" +
                                         "<p>SR komandasına yeni işçi qatılır!</p>" +
                                         $" <img height=\"240\" width=\"260\" src=\"{fullpath + @"\wwwroot\profile\" + userProfile}\" alt=\"img-edit\">" +
                                         $"\r\n\r\n<p><strong>{userFullName}</strong></p>" +
                                         $"\r\n\r\n<p>{company} ({department}/{position})</p>" +
                                        "\r\n\r\n<p>İş yeri ilə tanış olmasına,\r\n\r\n" +
                                        "ona şirkətimizin xoş atmosferinə mümkün qədər" +
                                        "\r\n\r\n tez uyğunlaşmasına  kömək edəcəyinizə inanırıq və \r\n\r\n" +
                                        "əməkdaşımıza uğurlar arzu edirik!</p>\r\n\r\n")
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            HrSend(emailMessage);
        }

        public async void ContactChangeSendEmail(string userCFullname, string usrName, string gender, string companyName, string positionName)
        {
            var smtpSettings = await _settingsService.GetAsync(z => z.Id == 1);
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No-Reply", smtpSettings.HrMail));
            emailMessage.To.Add(MailboxAddress.Parse("ilkin.nazarli@srgroupco.com"));

            emailMessage.Subject = "Vəzifə Dəyişikliyi";
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<p>Hörmətli həmkarlar,</p>\r\n\r\n" +
                                         $"\r\n<p>Nəzərinizə çatdırmaq istərdim ki, {userCFullname} artıq {companyName} şirkətində {positionName} olaraq fəaliyyətinə davam edəcəkdir. </p>" +
                                         $"\r\n<p>{usrName} "+" "+$" {gender}" +
                                         ", yeni pozisiyanızda Sizə uğurlar diləyirik!</p>")
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            HrSend(emailMessage);
        }
    }
}
