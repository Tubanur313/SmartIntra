using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class DashboardController : BaseIdentityController
    {
        private readonly ITicketService _ticketservice;
        private readonly IAppUserService _userservice;
        private readonly IOrderService _orderservice;
        private readonly ICompanyService _companyService;
        private readonly IDepartmentService _departmentService;
        private readonly ICategoryService _categoryService;
        public DashboardController
       (
       IMapper map,
       UserManager<IntranetUser> userManager,
       IHttpContextAccessor httpContextAccessor,
       SignInManager<IntranetUser> signInManager,
       ITicketService ticketservice,
       IAppUserService userservice,
       IOrderService orderservice,
       ICategoryService categoryService,
       ICompanyService companyService,
       IDepartmentService departmentService
       ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _ticketservice = ticketservice;
            _userservice = userservice;
            _orderservice = orderservice;
            _categoryService = categoryService;
            _companyService = companyService;
            _departmentService = departmentService;
        }
        [Authorize(Policy = "dashboard.menu")]
        public async Task<IActionResult> Menu()
        {
            decimal totalCountTicket = _ticketservice.GetAllAsync(x => x.IsDeleted == false).Result.Count;
            decimal closeCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Close && x.IsDeleted == false).Result.Count;
            decimal openCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Open && x.IsDeleted == false).Result.Count;
            decimal pauseCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Pause && x.IsDeleted == false).Result.Count;
            ViewBag.NullSupportedCountTicket = _ticketservice.GetAllAsync(x => !x.IsDeleted && x.SupporterId == null).Result.Count;

            ViewBag.todayCloseCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Close && x.IsDeleted == false && x.CreatedDate == DateTime.Now).Result.Count;
            ViewBag.todayOpenCountTicket = _ticketservice.GetAllAsync(x => x.StatusType != StatusType.Close && x.IsDeleted == false && x.CreatedDate == DateTime.Now).Result.Count;
            ViewBag.todayTotalCountTicket = _ticketservice.GetAllAsync(x => x.IsDeleted == false && x.CreatedDate == DateTime.Now).Result.Count;

            ViewBag.totalCountUsers = _userservice.GetAllAsync(x => x.IsDeleted == false).Result.Count;
            ViewBag.totalCountOrders = _orderservice.GetAllAsync(x => x.IsDeleted == false).Result.Count;
            ViewBag.totalCountTicket = totalCountTicket;
            ViewBag.closeCountTicket = closeCountTicket;

            if (totalCountTicket!=0)
            {
            ViewBag.OpenCount = (openCountTicket / totalCountTicket) * 100;
            ViewBag.CloseCount = (closeCountTicket / totalCountTicket) * 100;
            ViewBag.PauseCount = (pauseCountTicket / totalCountTicket) * 100;
            }
            else
            {
            ViewBag.OpenCount = 0;
            ViewBag.CloseCount = 0;
            ViewBag.PauseCount = 0;

            }
            ViewBag.departTotalCountTicket = _ticketservice.GetAllAsync(x => x.IsDeleted == false && x.SupporterId != null).Result.Count;
            decimal departcloseCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Close && x.IsDeleted == false).Result.Count;
            decimal departopenCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Open && x.IsDeleted == false).Result.Count;
            decimal departpauseCountTicket = _ticketservice.GetAllAsync(x => x.StatusType == StatusType.Pause && x.IsDeleted == false).Result.Count;

            return View();
        }

        public async Task<IActionResult> GetCompany()
        {

            return Ok(
            _map.Map<List<CompanyListDto>>(await _companyService.GetAllAsync())
            .Select(x => new
            {
                type = x.Name,
                visits = _ticketservice.GetAllAsync(t => t.Employee.CompanyId == x.Id && t.IsDeleted == false)
                .Result.Count
            }).ToList()
                );
        }

        public async Task<IActionResult> GetCategory()
        {

            return Ok(
            _map.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync())
            .Select(x => new
            {
                type = x.Name,
                visits = _ticketservice.GetAllAsync(t => t.CategoryTicketId == x.Id && t.IsDeleted == false)
                .Result.Count
            }).ToList()
                );
        }

        public async Task<IActionResult> GetTicketByDepartAsync()
        {
            decimal proessCountTicket = _ticketservice.GetAllAsync(x => !x.IsDeleted && x.SupporterId != null).Result.Count;

            var departmentCount =
                _map.Map<List<DepartmentListDto>>(await _departmentService.GetAllAsync(x => !x.IsDeleted))
            .Select(s => new
            {
                Count = _ticketservice.GetByDepartmentAllIncAsync(s.Id).Result.Count,
            });
            var departmentName =
                _map.Map<List<DepartmentListDto>>(await _departmentService.GetAllIncludeAsync())
            .Select(s => new
            {
                s.Name,
                CompName = s.Company.Name.ToString()
            });
            List<string> names = new List<string>();
            foreach (var item in departmentName)
            {
                names.Add(item.CompName + "/" + item.Name);
            }
            List<decimal> counts = new List<decimal>();
            List<string> colors = new List<string>();
            foreach (var item in departmentCount)
            {
                var proc = (item.Count / proessCountTicket) * 100;
                counts.Add(Decimal.Floor(proc));
                colors.Add(GetRandomColor());
            }

            return Ok(
                new
                {
                    name = names,
                    count = counts,
                    colors = colors
                }
                );
        }

        private string GetRandomColor()
        {
            Random rnd = new Random();
            string hexOutput = String.Format("{0:X}", rnd.Next(0, 0xFFFFFF));
            while (hexOutput.Length < 6)
                hexOutput = "0" + hexOutput;
            return "#" + hexOutput;
        }
    }


}
