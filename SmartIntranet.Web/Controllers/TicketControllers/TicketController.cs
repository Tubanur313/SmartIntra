using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using SmartIntranet.Business.Email;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CategoryTicketDto;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ConfirmTicketUserDto;
using SmartIntranet.DTO.DTOs.DiscussionDto;
using SmartIntranet.DTO.DTOs.OrderDto;
using SmartIntranet.DTO.DTOs.PhotoDto;
using SmartIntranet.DTO.DTOs.TicketCheckListDto;
using SmartIntranet.DTO.DTOs.TicketDto;
using SmartIntranet.DTO.DTOs.TicketOrderDto;
using SmartIntranet.DTO.DTOs.WatcherDto;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{
    public class TicketController : BaseIdentityController
    {
        private readonly ITicketService _ticketService;
        private readonly ICheckListService _checkListService;
        private readonly ICategoryTicketService _categoryTicketService;
        private readonly IAppUserService _userService;
        private readonly IWatcherService _watcherService;
        private readonly IOrderService _orderService;
        private readonly ITicketOrderService _ticketOrderService;
        private readonly ITicketCheckListService _ticketCheckListService;
        private readonly IConfirmTicketUserService _confirmTicketUserService;
        private readonly ISmtpEmailService _emailService;
        private readonly IFileService _upload;
        private readonly IDiscussionService _discuss;
        private readonly IPhotoService _photo;
        private readonly ICompanyService _companyService;
        private readonly IDiscussionService _discussionService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmailService _emailSender;

        public TicketController(
            IMapper map,
            IEmailService emailSender,
            ITicketService ticketService,
            ICheckListService checkListService,
            ICategoryTicketService CategoryTicketService,
            IAppUserService userService,
            IOrderService orderService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IWatcherService watcherService,
            ITicketCheckListService ticketCheckListService,
            IConfirmTicketUserService confirmTicketUserService,
            ITicketOrderService ticketOrderService,
            ISmtpEmailService emailService,
            IPhotoService photo,
            IDiscussionService discuss,
            ICompanyService companyService,
            IFileService upload,
            IDiscussionService discussionService,
            IDepartmentService departmentService

            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _emailSender = emailSender;
            _emailService = emailService;
            _ticketService = ticketService;
            _checkListService = checkListService;
            _categoryTicketService = CategoryTicketService;
            _userService = userService;
            _orderService = orderService;
            _watcherService = watcherService;
            _ticketCheckListService = ticketCheckListService;
            _confirmTicketUserService = confirmTicketUserService;
            _ticketOrderService = ticketOrderService;
            _discuss = discuss;
            _companyService = companyService;
            _photo = photo;
            _upload = upload;
            _discussionService = discussionService;
            _departmentService = departmentService;

        }
        #region Ticket Mail
        [NonAction]
        private async Task<string> ExportToPdf(int ticketId)
        {

            var ticketOrderList = await _ticketOrderService.GetAllIncludeAsync(ticketId);

            int pdfRowIndex = 1;
            string filename = "OrderDetails-" + DateTime.Now.ToString("dd-MM-yyyy hh_mm_s_tt");
            string filepath = Path.Combine(Directory.GetCurrentDirectory()) + "/wwwroot/order/" + filename + ".pdf";

            string orderPath = "/order/" + filename + ".pdf";

            var update = await _ticketService.FindByIdAsync(ticketId);
            update.OrderPath = orderPath;
            await _ticketService.UpdateAsync(update);

            Document document = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            Font font1 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
            Font font2 = FontFactory.GetFont(FontFactory.COURIER, 8);

            float[] columnDefinitionSize = { 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F };
            PdfPTable table;
            PdfPCell cell;

            table = new PdfPTable(columnDefinitionSize)
            {
                WidthPercentage = 100
            };

            cell = new PdfPCell
            {
                BackgroundColor = new BaseColor(0xC0, 0xC0, 0xC0)
            };

            //table.AddCell(new Phrase("Id", font1));
            table.AddCell(new Phrase("Mehsul", font1));
            table.AddCell(new Phrase("Ö/V", font1));
            table.AddCell(new Phrase("Say", font1));
            table.AddCell(new Phrase("Qiymet(EDV/Xaric)", font1));
            table.AddCell(new Phrase("Cemi(V/X)", font1));
            table.AddCell(new Phrase("Vergi Növü", font1));
            table.AddCell(new Phrase("Yekun Mebleg(V/D)", font1));
            table.AddCell(new Phrase("Satici", font1));
            table.AddCell(new Phrase("Qeyd", font1));
            table.HeaderRows = 1;

            foreach (var data in ticketOrderList)
            {
                //table.AddCell(new Phrase(data.Order.Id.ToString(), font2));
                table.AddCell(new Phrase(data.Order.Product != null ? data.Order.Product.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Currency != null ? data.Order.Currency.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Quantity != null ? data.Order.Quantity.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.WithoutVat != null ? data.Order.WithoutVat.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.TotalWithoutTax != null ? data.Order.TotalWithoutTax.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.TaxType != null ? data.Order.TaxType.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Total != null ? data.Order.Total.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Seller != null ? data.Order.Seller.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Description != null ? data.Order.Description.ToString() : "", font2));

                pdfRowIndex++;
            }

            document.Add(table);
            document.Close();
            document.CloseDocument();
            document.Dispose();
            writer.Close();
            writer.Dispose();
            fs.Close();
            fs.Dispose();
            return orderPath;

        }

        [NonAction]
        private async void SendEmailAsync(string messageType, int ticketId)
        {
            List<string> toEmail2 = new List<string>();
            string watchers = string.Empty;
            //string orderList = string.Empty;
            StringBuilder confirmers = new StringBuilder();
            StringBuilder checklists = new StringBuilder();
            var smtpSettings = await _emailService.GetAsync(z => z.Id == 1);
            var ticket = await _ticketService.GetIncludeMailAsync(ticketId);
            //var watchersEmail= await _watcherService.GetAllAsync(y => y.TicketId==model.Id);
            //var confirmersEmail = await _confirmTicketUserService.GetAllAsync(y => y.TicketId == model.Id);


            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(smtpSettings.FromEmail));

            if (ticket.Watchers.Count != 0)
            {
                foreach (var item in ticket.Watchers)
                {
                    watchers += _map.Map<AppUserDetailsDto>(await _userService.FindByUserAllInc(item.IntranetUser.Id)).ToString() + "</br>";
                    toEmail2.Add(item.IntranetUser.Email);

                }
            }

            if (ticket.ConfirmTicketUsers.Count != 0)
            {
                foreach (var item in ticket.ConfirmTicketUsers)
                {
                    confirmers.Append(_map.Map<AppUserDetailsDto>(item.IntranetUser) + "  adlı nəzarətçi sifarişi");
                    confirmers.Append(item.ConfirmTicket ? "  təsdiq etdi ! </br>" : " təsdiq etməyib ! </br>");
                    toEmail2.Add(item.IntranetUser.Email);
                }
            }
            if (ticket.TicketCheckLists.Count != 0)
            {
                foreach (var item in ticket.TicketCheckLists)
                {
                    checklists.Append(item.CheckList.Name + "  adlı çeklist");
                    checklists.Append(item.Confirm ? "  həll olundu ! </br>" : " həll olunmayıb ! </br>");
                }
            }
            if (ticket.Supporter != null)
            {
                toEmail2.Add(ticket.Supporter.Email);
            }
            else
            {
                toEmail2.Add(smtpSettings.UserName);
            }

            foreach (var item in toEmail2)
            {
                email.To.Add(MailboxAddress.Parse(item));
            }

            email.Subject = ticket.Title;
            string callBackUrl = smtpSettings.BaseUrl + "/Ticket/Get/" + ticket.Id;
            if (ticket.Supporter != null && ticket.CategoryTicket.TicketType == TicketType.Task)
            {
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<h1><a href ='" + callBackUrl + "'>" + "#" + ticket.Id + messageType + "</a></h1>" +
                    "<p><strong>" + "Məzmun : </strong>" + ticket.Description + "</p>" +
                    "<p><strong>" + "Kateqoriya : </strong>" + ticket.CategoryTicket.Name + "</p>" +
                    "<p><strong>" + "Status : </strong>" + ticket.StatusType + "</p>" +
                    //"<p><strong>" + "Deadline : </strong>" + model.DeadLineEnd.Value.ToString("dd-MM-yyyy") + "</p>" +
                    "<p><strong>" + "Task Açan : </strong>" + ticket.Employee.Name + ticket.Employee.Surname + "</p>" +
                    "<p><strong>" + "Yönləndirilib : </strong>" + ticket.Supporter.Name + ticket.Supporter.Surname + "</p>" +
                    "<p><strong>" + "Təsdiq edənlər : </strong></br>" + confirmers + "</p>" +
                    "<p><strong>" + "Nəzarətçilər : </strong></br>" + watchers + "</p>" +
                    "<p><strong>" + "Çeklistlər : </strong></br> " + checklists + "</p>"
                };
            }
            else if (ticket.Supporter != null && ticket.CategoryTicket.TicketType != TicketType.Task)
            {
                //string filepath = await ExportToPdf(ticketId);

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<h1><a href ='" + callBackUrl + "'>" + "#" + ticket.Id + messageType + "</a></h1>" +
           "<p><strong>" + "Məzmun : </strong>" + ticket.Description + "</p>" +
           "<p><strong>" + "Kateqoriya : </strong>" + ticket.CategoryTicket.Name + "</p>" +
            "<a href ='" + smtpSettings.BaseUrl + ticket.OrderPath + "'>" + "Order Fayli" + "</a>" +
           "<p><strong>" + "Status : </strong>" + ticket.StatusType + "</p>" +
           //"<p><strong>" + "Deadline : </strong>" + model.DeadLineEnd.Value.ToString("dd-MM-yyyy") + "</p>" +
           "<p><strong>" + "Task Açan : </strong>" + ticket.Employee.Name + ticket.Employee.Surname + "</p>" +
           "<p><strong>" + "Yönləndirilib : </strong>" + ticket.Supporter.Name + ticket.Supporter.Surname + "</p>" +
           "<p><strong>" + "Təsdiq edənlər : </strong></br>" + confirmers + "</p>" +
           "<p><strong>" + "Nəzarətçilər : </strong></br>" + watchers + "</p>" +
           "<p><strong>" + "Çeklistlər : </strong></br> " + checklists + "</p>"
                };




            }
            else if (ticket.Supporter == null && ticket.CategoryTicket.TicketType == TicketType.Task)
            {
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<h1><a href ='" + callBackUrl + "'>" + "#" + ticket.Id + messageType + "</a></h1>" +
                   "<p><strong>" + "Məzmun : </strong>" + ticket.Description + "</p>" +
                   "<p><strong>" + "Kateqoriya : </strong>" + ticket.CategoryTicket.Name + "</p>" +
                   "<p><strong>" + "Status : </strong>" + ticket.StatusType.GetDisplayName() + "</p>" +
                   //"<p><strong>" + "Deadline : </strong>" + model.DeadLineEnd.Value.ToString("dd-MM-yyyy") + "</p>" +
                   "<p><strong>" + "Task Açan : </strong>" + ticket.Employee.Name + ticket.Employee.Surname + "</p>" +
                   //"<p><strong>" + "Yönləndirilib : </strong>" + ticket.Supporter.FullName + "</p>" +
                   "<p><strong>" + "Təsdiq edənlər : </strong></br>" + confirmers + "</p>" +
                   "<p><strong>" + "Nəzarətçilər : </strong></br>" + watchers + "</p>" +
                   "<p><strong>" + "Çeklistlər : </strong></br> " + checklists + "</p>"
                };
            }
            else
            {
                //string filepath = await ExportToPdf(ticketId);
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<h1><a href ='" + callBackUrl + "'>" + "#" + ticket.Id + messageType + "</a></h1>" +
                "<p><strong>" + "Məzmun : </strong>" + ticket.Description + "</p>" +
                "<p><strong>" + "Kateqoriya : </strong>" + ticket.CategoryTicket.Name + "</p>" +
                "<h3><a href ='" + smtpSettings.BaseUrl + ticket.OrderPath + "'>" + "Order Fayli" + "</a></h3>" +
                "<p><strong>" + "Status : </strong>" + ticket.StatusType + "</p>" +
                //"<p><strong>" + "Deadline : </strong>" + model.DeadLineEnd.Value.ToString("dd-MM-yyyy") + "</p>" +
                "<p><strong>" + "Task Açan : </strong>" + ticket.Employee.Name + "</p>" +
                //"<p><strong>" + "Yönləndirilib : </strong>" + ticket.Supporter.FullName + "</p>" +
                "<p><strong>" + "Təsdiq edənlər : </strong></br>" + confirmers + "</p>" +
                "<p><strong>" + "Nəzarətçilər : </strong></br>" + watchers + "</p>" +
                "<p><strong>" + "Çeklistlər : </strong></br> " + checklists + "</p>"
                };

            }
            // send email

            SmtpClient smtp = new SmtpClient();
            smtp.Connect(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(smtpSettings.FromEmail, smtpSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        #endregion
        #region Ticket Listing 
        [HttpGet]
        [Authorize(Policy = "ticket.admin")]
        public async Task<IActionResult> Admin()
        {
            var model = _map.Map<List<TicketListDto>>(await _ticketService
             .GetForAdminAsync());
            if (model is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
                ViewData["active"] = "active";
                return View(new List<TicketListDto>());

            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
            ViewData["active"] = "active";
            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.nonRedirect")]
        public async Task<IActionResult> Admin(int CategoryTicketId, StatusType statusType, int companyId)
        {
            var model = _map.Map<List<TicketListDto>>(await _ticketService.GetForAdminAsync(CategoryTicketId, statusType, companyId));
            ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
            if (model.Count > 0)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
                return View(_map.Map<List<TicketListDto>>(model));
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
            return View(new List<TicketListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "ticket.list")]
        public async Task<IActionResult> List(string success, string error)
        {
            var model = _map.Map<List<TicketListDto>>(await _ticketService
             .GetListedBySignInUserIdAsync(GetSignInUserId()));


            if (model is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(new List<TicketListDto>());

            }
            TempData["success"] = success;
            TempData["error"] = error;
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.list")]
        public async Task<IActionResult> List(
            int CategoryTicketId,
            StatusType statusType
            )
        {
            List<Ticket> model = await _ticketService
                .GetListedBySignInUserIdAsync(GetSignInUserId(),
                CategoryTicketId, statusType
                );

            if (model.Count > 0)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(_map.Map<List<TicketListDto>>(model));
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());

            return View(new List<TicketListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "ticket.get")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _ticketService.GetAllIncludeAsync(id);
            if (model != null)
            {
                return View(_map.Map<List<TicketListDto>>(model));
            }
            return View(new List<TicketListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "ticket.nonRedirect")]
        public async Task<IActionResult> NonRedirect()
        {
            var model = _map.Map<List<TicketListDto>>(await _ticketService
             .GetNonRedirectedAsync());
            if (model is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
                return View(new List<TicketListDto>());

            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.nonRedirect")]
        public async Task<IActionResult> NonRedirect(int CategoryTicketId, StatusType statusType,int companyId)
        {
            var model = _map.Map<List<TicketListDto>>(await _ticketService.GetNonRedirectedAsync(CategoryTicketId, statusType, companyId));
                ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
            if (model.Count > 0)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
                return View(_map.Map<List<TicketListDto>>(model));
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            ViewBag.company = _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync());
            return View(new List<TicketListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "ticket.watched")]
        public async Task<IActionResult> Watched()
        {
            var watchers = _map.Map<List<WatcherListDto>>(await _watcherService
             .MyWatchedTicketsAsync(GetSignInUserId()));
            var tickets = new List<TicketListDto>();
            foreach (var wTickets in watchers)
            {
                tickets.Add(_map.Map<TicketListDto>(wTickets.Ticket));
            }

            if (tickets is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(new List<TicketListDto>());

            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            return View(tickets);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.watched")]
        public async Task<IActionResult> Watched(int CategoryTicketId,
            StatusType statusType)
        {
            var model = await _watcherService.MyWatchedTicketsAsync(GetSignInUserId()
                , CategoryTicketId, statusType);
            List<TicketListDto> tickets = new List<TicketListDto>();
            foreach (var ticket in model)
            {
                tickets.Add(_map.Map<TicketListDto>(ticket.Ticket));
            }
            if (tickets.Count > 0)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                var result = _map.Map<List<TicketListDto>>(tickets);
                return View(result);
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            return View(new List<TicketListDto>());
        }
        [Authorize(Policy = "ticket.confirmNotify")]
        public async Task<IActionResult> ConfirmNotify()
        {
            List<ConfirmTicketUser> model = _map.Map<List<ConfirmTicketUser>>(await _confirmTicketUserService
                .MyConfirmNeedTicketsAsync(GetSignInUserId()));

            if (model != null)
            {
                return Ok(model.Select(x => new
                {
                    ticketId = x.TicketId,
                    confirmTicket = x.ConfirmTicket
                }));
            }
            return BadRequest();
        }
        [HttpGet]
        [Authorize(Policy = "ticket.confirmed")]
        public async Task<IActionResult> Confirmed()
        {
            var confirms = _map.Map<List<ConfirmTicketUserListDto>>(await _confirmTicketUserService
             .MyConfirmNeedTicketsAsync(GetSignInUserId()));
            var tickets = new List<TicketListDto>();
            foreach (var cTickets in confirms)
            {
                tickets.Add(_map.Map<TicketListDto>(cTickets.Ticket));
            }
            if (tickets is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(new List<TicketListDto>());
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            return View(tickets);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.confirmed")]
        public async Task<IActionResult> Confirmed(int CategoryTicketId,
        StatusType statusType)
        {
            List<ConfirmTicketUser> model = await _confirmTicketUserService
                .MyConfirmNeedTicketsAsync(GetSignInUserId(), CategoryTicketId, statusType);

            List<TicketListDto> tickets = new List<TicketListDto>();

            foreach (var ticket in model)
            {
                tickets.Add(_map.Map<TicketListDto>(ticket.Ticket));

            }
            if (tickets.Count > 0)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                var result = _map.Map<List<TicketListDto>>(tickets);

                return View(result);
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            return View(new List<TicketListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "ticket.departmenttickets")]
        public async Task<IActionResult> DepartmentTickets()
        {
            var user = await _userService.GetAsync(x => x.Id == GetSignInUserId());
            if (user.DepartmentId is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(new List<TicketListDto>());
            }
            List<TicketListDto> model = _map.Map<List<TicketListDto>>(await _ticketService
               .GetByUserDepartmentAllIncAsync((int)user.DepartmentId)
            );
            if (model is null)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(new List<TicketListDto>());
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.list")]
        public async Task<IActionResult> DepartmentTickets(
    int categoryId,
    StatusType statusType
    )
        {
            var user = await _userService.GetAsync(x => x.Id == GetSignInUserId());
            List<TicketListDto> model = _map.Map<List<TicketListDto>>(await _ticketService
               .GetByUserDepartmentAllIncAsync((int)user.DepartmentId, categoryId, statusType)
            );
            if (model.Count > 0)
            {
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
                return View(_map.Map<List<TicketListDto>>(model));
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());

            return View(new List<TicketListDto>());
        }
        #endregion
        #region Ticket Cruds
        [HttpGet]
        [Authorize(Policy = "ticket.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            ViewBag.cheklist = _map.Map<List<CheckListListDto>>(await _checkListService.GetAllAsync());
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "ticket.add")]
        [RequestFormLimits(MultipartBodyLengthLimit = 4200000000)]
        [RequestSizeLimit(4200000000)]
        public async Task<IActionResult> Add(TicketAddDto model, List<IFormFile> uploads)
        {

            if (ModelState.IsValid)
            {

                var CategoryTicketSupporter = _map.Map<CategoryTicketListDto>(await _categoryTicketService.GetIncludeAsync(model.CategoryTicketId));
                var add = _map.Map<Ticket>(model);
                add.CreatedByUserId = GetSignInUserId();
                add.EmployeeId = GetSignInUserId();
                add.SupporterId = CategoryTicketSupporter.SupporterId;

                var result = await _ticketService.AddReturnEntityAsync(add);

                if (result is null)
                {
                    return RedirectToAction("List", new
                    {
                        error = Messages.Add.notAdded
                    });
                }
                var ticketResult = await _ticketService.FindAllIncludeForInfoAsync(result.Id);
                if (model.AppUserWatcherId != null)
                {
                    foreach (var intranetUserId in model.AppUserWatcherId)
                    {
                        WatcherAddDto watcher = new WatcherAddDto
                        {
                            IntranetUserId = intranetUserId,
                            TicketId = result.Id
                        };
                        var mapWatcher = _map.Map<Watcher>(watcher);
                        mapWatcher.CreatedByUserId = GetSignInUserId();
                        var watchResult = await _watcherService
                            .AddReturnEntityAsync(mapWatcher);
                        //wathcers += _map.Map<AppUserDetailsDto>(await _userService.FindByUserAllInc(intranetUserId)).ToString() + "</br>";
                        //toEmail.Add(_map.Map<AppUserDetailsDto>(await _userService.FindByUserAllInc(intranetUserId)).Email);
                    }
                }

                if (model.Confirmed)
                {
                    foreach (var intranetUserId in model.ConfirmTicketUserId)
                    {
                        ConfirmTicketUserAddDto confirm = new ConfirmTicketUserAddDto
                        {
                            IntranetUserId = intranetUserId,
                            TicketId = result.Id
                        };
                        var mapConfirm = _map.Map<ConfirmTicketUser>(confirm);
                        mapConfirm.CreatedByUserId = GetSignInUserId();
                        var confirmResult = await _confirmTicketUserService
                        .AddReturnEntityAsync(mapConfirm);
                        //confirmers += _map.Map<AppUserDetailsDto>(await _userService.FindByUserAllInc(intranetUserId)).ToString() + "</br>";
                        //toEmail.Add(_map.Map<AppUserDetailsDto>(await _userService.FindByUserAllInc(intranetUserId)).Email);

                    }
                }
                if (model.CheckListId != null)
                {
                    foreach (var checkId in model.CheckListId)
                    {
                        TicketCheckListAddDto check = new TicketCheckListAddDto
                        {
                            CheckListId = checkId,
                            TicketId = result.Id
                        };
                        var mapCheck = _map.Map<TicketCheckList>(check);
                        mapCheck.CreatedByUserId = GetSignInUserId();
                        var checklistResult = await _ticketCheckListService
                             .AddReturnEntityAsync(mapCheck);
                        //checklists += _map.Map<CheckListListDto>(await _checkListService.FindByIdAsync(checkId)).Name + "</br>";
                    }
                }
                List<int> ordersIds = JsonConvert.DeserializeObject<List<int>>(model.OrderIds);
                if (ordersIds.Count > 0)
                {
                    foreach (var id in ordersIds)
                    {
                        TicketOrderAddDto ticketOrder = new TicketOrderAddDto
                        {
                            OrderId = id,
                            TicketId = result.Id,
                        };

                        var mappedTO = _map.Map<TicketOrder>(ticketOrder);
                        mappedTO.CreatedByUserId = GetSignInUserId();
                        await _ticketOrderService.AddReturnEntityAsync(mappedTO);

                    }

                }
                foreach (var upload in uploads)
                {
                    if (!(upload is null))
                    {
                        if (MimeTypeCheckExtension.İsImage(upload))
                        {
                            string folder = "/ticketPhoto/";
                            string name = _upload.UploadResizedImg(upload, "wwwroot" + folder);
                            PhotoAddDto dto = new PhotoAddDto
                            {
                                Name = name,
                                Path = HttpContext.Request.Host.Value + folder + name,
                                TicketId = result.Id
                            };
                            var photo = _map.Map<Photo>(dto);
                            photo.CreatedByUserId = GetSignInUserId();
                            await _photo.AddAsync(photo);

                        }
                        else if (MimeTypeCheckExtension.İsDocument(upload))
                        {
                            
                            string folder = "/ticketFile/";
                            string name = await _upload.Upload(upload, "wwwroot" + folder);
                            PhotoAddDto dto = new PhotoAddDto
                            {
                                Name = name,
                                Path = HttpContext.Request.Host.Value + folder + name,
                                TicketId = result.Id
                            };
                            var photo = _map.Map<Photo>(dto);
                            photo.CreatedByUserId = GetSignInUserId();
                            await _photo.AddAsync(photo);
                        }
                        else
                        {
                            if (CategoryTicketSupporter.Supporter != null)
                            {
                                SendEmailAsync(" Nomreli Task Yaradildi", result.Id);
                            }
                            return RedirectToAction("List", new
                            {
                                success = Messages.Add.Added + $"{upload.ContentType.GetType()} formatı uyğun format deyil"
                            });
                        }
                    }
                }
                if(ticketResult.CategoryTicket.TicketType != TicketType.Task)
                {
                   await ExportToPdf(result.Id);
                }
                var message = " Nomreli Task Yaradildi";
                if (CategoryTicketSupporter.Supporter != null)
                {
                    //SendEmailAsync(message, result.Id);
                    var messages = new Message(new string[] { "mahir.tahiroghlu@srgroupco.com" }, "Test mail with Attachments", "This is the content from our mail with attachments.");
                    await _emailSender.SendEmailAsync(messages);
                }
                return RedirectToAction("List", new
                {
                    success = Messages.Add.Added
                });
            }
            else
            {
                return RedirectToAction("List", new
                {
                    error = Messages.Error.notComplete
                });
            }
        }
        [HttpGet]
        [Authorize(Policy = "ticket.info")]
        public async Task<IActionResult> Info(int id)
        {
            TicketInfoDto data = _map.Map<TicketInfoDto>(await _ticketService.FindAllIncludeForInfoAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
            }
            ViewBag.GrandTotal = _ticketService.GetAsync(x => x.Id == id).Result.GrandTotal;
            ViewBag.DiscCount = _discussionService.GetAllAsync(x=>x.TicketId==id).Result.Count;
            return View(data);
        }

        [Authorize(Policy = "ticket.delete")]
        public async Task Delete(int id)
        {
            var delete = await _ticketService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _ticketService.UpdateAsync(delete);
        }
        #endregion
        #region Ticket Modals 

        [HttpGet]
        [Authorize(Policy = "ticket.orders")]
        public async Task<IActionResult> Orders(int id)
        {
            List<TicketOrderListDto> tOrders = _map
                .Map<List<TicketOrderListDto>>(await _ticketOrderService.FindOrdersByTicketId(id));
            List<OrderListDto> orders = new List<OrderListDto>();

            foreach (var order in tOrders)
            {
                orders.Add(_map.Map<OrderListDto>(order.Order));
            }

            if (orders is null)
            {
                TempData["error"] = Messages.Error.notFound;
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            ViewBag.ticketId = id;
            ViewBag.GrandTotal = _ticketService.GetAsync(x => x.Id == id).Result.GrandTotal;
            //var ticket = await _ticketService.FindByIdAsync(id);
            //ticket.GrandTotal = "0.00";
            //await _ticketService.UpdateAsync(ticket);
            return View(orders);
        }

        [HttpGet]
        [Authorize(Policy = "ticket.orderUpdate")]
        public async Task<IActionResult> OrderUpdate(int ticketId)
        {
           await ExportToPdf(ticketId);
            string message = " Taskın Order faylında dəyişiklik olundu";
            SendEmailAsync(message, ticketId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GrandTotal(decimal gTotal, int ticketId)
        {
            var ticket = await _ticketService.GetAsync(x => x.Id == ticketId);
            if (ticket != null)
            {
                ticket.GrandTotal = gTotal.ToString();
            }
            await _ticketService.UpdateAsync(ticket);
            return Ok();
        }
        [HttpGet]
        [Authorize(Policy = "ticket.categoryticket")]
        public async Task<IActionResult> CategoryTicket(int id)
        {
            TicketCategoryDto data = _map.Map<TicketCategoryDto>(await _ticketService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());
            }
            ViewBag.categories = _map.Map<List<CategoryTicketListDto>>(await _categoryTicketService.GetAllIncludeAsync());

            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.categoryticket")]
        public async Task<IActionResult> CategoryTicket(TicketCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _ticketService.FindByIdAsync(model.Id);
                data.UpdateByUserId = GetSignInUserId();
                data.UpdateDate = DateTime.Now;
                data.CategoryTicketId = model.CategoryTicketId;
                await _ticketService.UpdateModifiedAsync(data);

                SendEmailAsync(" Nomreli Task Kateqoriya Yeniləndi", model.Id);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            return RedirectToAction("List", new
            {
                success = Messages.Error.notComplete
            });
        }

        [HttpGet]
        [Authorize(Policy = "ticket.checklist")]
        public async Task<IActionResult> Checklist(int id)
        {
            var ticket = _map.Map<TicketCheklistDto>(await _ticketService.FindForCheckingsAsync(id));

            if (ticket is null)
            {
                ViewBag.cheklist = _map.Map<List<CheckListListDto>>(await _checkListService.GetAllAsync());
                TempData["error"] = Messages.Error.notFound;
            }
            ViewBag.cheklist = _map.Map<List<CheckListListDto>>(await _checkListService.GetAllAsync());

            return View(ticket);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.checklist")]
        public async Task<IActionResult> Checklist(TicketCheklistDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.CheckListId != null)
                {
                    foreach (var checkListId in model.CheckListId)
                    {
                        if (!await _ticketCheckListService.AnyAsync(x => x.TicketId == model.Id && x.CheckListId == checkListId))
                        {
                            TicketCheckListAddDto tcl = new TicketCheckListAddDto
                            {
                                CheckListId = checkListId,
                                TicketId = model.Id
                            };
                            var mapTcl = _map.Map<TicketCheckList>(tcl);
                            mapTcl.CreatedByUserId = GetSignInUserId();
                            await _ticketCheckListService
                            .AddReturnEntityAsync(mapTcl);
                        }
                    }
                }
                SendEmailAsync(" Nomreli Task Checklistler Yeniləndi", model.Id);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            return RedirectToAction("List", new
            {
                error = Messages.Error.notComplete
            });
        }
        [HttpGet]
        [Authorize(Policy = "ticket.confirm")]
        public async Task<IActionResult> Confirm(int id)
        {
            TicketConfirmDto ticket = _map.Map<TicketConfirmDto>(await _ticketService
                .FindForConfirmAsync(id));
            if (ticket is null)
            {
                TempData["error"] = Messages.Error.notFound;
            }
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            ViewBag.signInUserId = GetSignInUserId();
            return View(ticket);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.confirm")]
        public async Task<IActionResult> Confirm(TicketConfirmDto model)
        {
            if (ModelState.IsValid)
            {
                if (!model.Confirmed && model.ConfirmTicketUserId != null)
                {
                    var ticket = await _ticketService.FindByIdAsync(model.Id);
                    ticket.Confirmed = model.Confirmed;
                    await _ticketService.UpdateModifiedAsync(ticket);
                    //SendEmailAsync(" Nomreli Taska Tesdiq Sorgusu Elave olundu", model.Id);
                    return RedirectToAction("List", new
                    {
                        success = Messages.Update.confirmed
                    });
                }
                if (model.ConfirmTicketUserId != null)
                {
                    foreach (var intranetUserId in model.ConfirmTicketUserId)
                    {
                        if (!await _confirmTicketUserService
                            .AnyAsync(x => x.TicketId == model.Id && x.IntranetUserId == intranetUserId))
                        {
                            ConfirmTicketUserAddDto confirm = new ConfirmTicketUserAddDto
                            {
                                IntranetUserId = intranetUserId,
                                TicketId = model.Id
                            };
                            var mapConfirm = _map.Map<ConfirmTicketUser>(confirm);
                            mapConfirm.CreatedByUserId = GetSignInUserId();
                            var confirmers = await _confirmTicketUserService
                            .AddReturnEntityAsync(mapConfirm);
                        }
                    }
                    var ticket = await _ticketService.FindByIdAsync(model.Id);
                    ticket.Confirmed = model.Confirmed;
                    await _ticketService.UpdateModifiedAsync(ticket);
                    //SendEmailAsync(" Nomreli Task Tesdiqlendi", model.Id);
                    TempData["success"] = "Təsdiqləyənlər siyahısı yeniləndi";
                    return RedirectToAction("Confirmed");
                }
                SendEmailAsync(" Nomreli Task Tesdiqlendi", model.Id);
                return RedirectToAction("Confirmed");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("Confirmed");
        }
        [HttpGet]
        [Authorize(Policy = "ticket.watchers")]
        public async Task<IActionResult> Watchers(int id)
        {
            TicketWathcersDto ticket = _map.Map<TicketWathcersDto>(await _ticketService.FindForWatchersAsync(id));
            if (ticket is null)
            {
                TempData["error"] = Messages.Error.notFound;
            }
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            ViewBag.signInUserId = GetSignInUserId();
            return View(ticket);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.watchers")]
        public async Task<IActionResult> Watchers(TicketWathcersDto model)
        {
            if (ModelState.IsValid)
            {
                foreach (var intranetUserId in model.AppUserWatcherId)
                {
                    if (!await _watcherService
                        .AnyAsync(x => x.TicketId == model.Id && x.IntranetUserId == intranetUserId))
                    {
                        WatcherAddDto watchers = new WatcherAddDto
                        {
                            IntranetUserId = intranetUserId,
                            TicketId = model.Id
                        };
                        var mapConfirm = _map.Map<Watcher>(watchers);
                        mapConfirm.CreatedByUserId = GetSignInUserId();
                        var confirmers = await _watcherService
                        .AddReturnEntityAsync(mapConfirm);
                    }
                }
                //SendEmailAsync(" Nomreli Task Nəzarətçilər yeniləndi", model.Id);
                TempData["success"] = "Nəzarətçilər siyahısı yeniləndi";
                return RedirectToAction("Watched");

            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("Watched");
        }
        [HttpGet]
        [Authorize(Policy = "ticket.redirect")]
        public async Task<IActionResult> Redirect(int id)
        {
            TicketRedirectDto data = _map.Map<TicketRedirectDto>(await _ticketService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
            }
            ViewBag.users = _map.Map<List<AppUserDetailsDto>>(await _userService.GetAllIncludeAsync());
            //SendEmailAsync(List<string> )
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.redirect")]
        public async Task<IActionResult> Redirect(TicketRedirectDto model)
        {
            if (ModelState.IsValid)
            {
                var update = await _ticketService.FindByIdAsync(model.Id);
                update.UpdateByUserId = GetSignInUserId();
                update.UpdateDate = DateTime.Now;
                update.SupporterId = model.SupporterId;

                await _ticketService.UpdateAsync(update);
                SendEmailAsync("Nomreli Task Yönləndirildi", model.Id);
                TempData["success"] = "Ticket Yönləndirildi";
                return RedirectToAction("NonRedirect");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("NonRedirect");
        }
        [HttpGet]
        [Authorize(Policy = "ticket.status")]
        public async Task<IActionResult> Status(int id)
        {
            TicketStatusDto data = _map.Map<TicketStatusDto>(await _ticketService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.status")]
        public async Task<IActionResult> Status(TicketStatusDto model)
        {
            if (ModelState.IsValid)
            {
                var update = await _ticketService.FindByIdAsync(model.Id);
                update.UpdateByUserId = GetSignInUserId();
                update.UpdateDate = DateTime.Now;
                update.StatusType = model.StatusType;

                await _ticketService.UpdateAsync(update);
                SendEmailAsync(" Nomreli Taskın Statusu Dəyişdirildi", model.Id);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            return RedirectToAction("List", new
            {
                error = Messages.Error.notComplete
            });
        }
        [HttpGet]
        [Authorize(Policy = "ticket.priority")]
        public async Task<IActionResult> Priority(int id)
        {
            TicketPriorityDto data = _map.Map<TicketPriorityDto>(await _ticketService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "ticket.priority")]
        public async Task<IActionResult> Priority(TicketPriorityDto model)
        {
            if (ModelState.IsValid)
            {
                var update = await _ticketService.FindByIdAsync(model.Id);
                update.UpdateByUserId = GetSignInUserId();
                update.UpdateDate = DateTime.Now;
                update.PriorityType = model.PriorityType;

                await _ticketService.UpdateAsync(update);
                //SendEmailAsync(" Nomreli Taskın Prioriteti Dəyişdirildi", model.Id);
                return RedirectToAction("List", new
                {
                    success = Messages.Update.updated
                });
            }
            return RedirectToAction("List", new
            {
                error = Messages.Error.notComplete
            });
        }
        #endregion
        #region Tickets Other Actions
        [HttpGet]
        [Authorize(Policy = "ticket.search")]
        public IActionResult Search()
        {
            return View(new List<TicketListDto>());
        }
        [HttpPost]
        [Authorize(Policy = "ticket.search")]
        public async Task<IActionResult> Search(int search)
        {
            var model = await _ticketService.GetAllIncludeAsync(search);
            if (model != null)
            {
                return View(_map.Map<List<TicketListDto>>(model));
            }
            return View(new List<TicketListDto>());
        }

        [Authorize(Policy = "ticket.discuss")]
        public async Task<IActionResult> Discuss(DiscussionAddDto model)
        {
            var add = _map.Map<Discussion>(model);
            add.CreatedByUserId = GetSignInUserId();
            add.IntranetUserId = GetSignInUserId();
            var result = await _discuss.AddReturnEntityAsync(add);
            var count = await _discuss.GetAllAsync(x => x.TicketId == result.TicketId);

            var discuss = _map.Map<DiscussionListDto>(await _discuss.GetAllIncludeAsync(result.Id));
            return Ok(new
            {
                fulname = _map.Map<AppUserDetailsDto>(discuss.IntranetUser).ToString(),
                comment = discuss.Content,
                date = discuss.CreatedDate.Value.ToString("dd.MM.yyyy HH:mm:ss"),
                count = count.Count
            });
        }

        [HttpPost]
        [Authorize(Policy = "ticket.load")]
        public async Task<IActionResult> Load(int Id, IFormFile[] files)
        {
            foreach (var upload in files)
            {
                if (!(upload is null))
                {
                    if (MimeTypeCheckExtension.İsImage(upload))
                    {
                        string folder = "/ticketPhoto/";
                        string name = _upload.UploadResizedImg(upload, "wwwroot" + folder);
                        PhotoAddDto dto = new PhotoAddDto
                        {
                            Name = name,
                            //Path = HttpContext.Request.Host.Value + folder + name,
                            TicketId = Id
                        };
                        var photo = _map.Map<Photo>(dto);
                        photo.CreatedByUserId = GetSignInUserId();
                        await _photo.AddAsync(photo);

                    }
                    else if (MimeTypeCheckExtension.İsDocument(upload))
                    {
                        string folder = "/ticketFile/";
                        string name = await _upload.Upload(upload, "wwwroot" + folder);
                        PhotoAddDto dto = new PhotoAddDto
                        {
                            Name = name,
                            Path = HttpContext.Request.Host.Value + folder + name,
                            TicketId = Id
                        };
                        var photo = _map.Map<Photo>(dto);
                        photo.CreatedByUserId = GetSignInUserId();
                        await _photo.AddAsync(photo);
                    }
                    else
                    {
                        return Ok("Tiket Əlavə olundu" + $"{upload.ContentType.GetType()} formatı uyğun format deyil");
                    }
                }
            }
            return Ok("Tiket Əlavə olundu");
        }
        #endregion
    }

}
