using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DTO.DTOs.OrderDto;
using SmartIntranet.DTO.DTOs.TicketDto;
using SmartIntranet.DTO.DTOs.TicketOrderDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class OrderController : BaseIdentityController
    {
        private readonly IOrderService _orderService;
        private readonly ITicketOrderService _ticketOrderService;
        private readonly ITicketService _ticketService;
        public OrderController
            (
            IMapper map,
            IOrderService orderService,
            ITicketOrderService tickeOrderService,
            ITicketService ticketService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _orderService = orderService;
            _ticketOrderService = tickeOrderService;
            _ticketService = ticketService;
        }
        [Authorize(Policy = "order.list")]
        public async Task<IActionResult> List()
        {
            var model = await _orderService.GetAllAsync(x => x.IsDeleted == false);
            if (model.Count > 0)
            {
                return View(_map.Map<List<OrderListDto>>(model));
            }
            return View(new List<OrderListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "order.add")]
        public async Task<IActionResult> Add(OrderAddDto data)
        {
            var map = _map.Map<Order>(data);
            map.CreatedByUserId = GetSignInUserId();
            map.CreatedDate = DateTime.UtcNow;
            var result = await _orderService.AddReturnEntityAsync(map);
            if (data.TicketId !=0)
            {
                TicketOrderAddDto ticketOrder = new TicketOrderAddDto
                {
                    OrderId = result.Id,
                    TicketId = data.TicketId,
                };

                var mappedTO = _map.Map<TicketOrder>(ticketOrder);
                mappedTO.CreatedByUserId = GetSignInUserId();
                mappedTO.CreatedDate = DateTime.UtcNow;
                await _ticketOrderService.AddReturnEntityAsync(mappedTO);
            }

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result.Id);
        }
        [HttpGet]
        [Authorize(Policy = "order.update")]
        public async Task<IActionResult> Update(OrderListDto data)
        {
            var model = await _orderService.FindByIdAsync(data.Id);
            Order update = _map.Map<Order>(data);
            update.UpdateByUserId = GetSignInUserId();
            update.CreatedByUserId = model.CreatedByUserId;
            update.CreatedDate = model.CreatedDate;
            update.UpdateDate = DateTime.UtcNow;
            var result = await _orderService.UpdateReturnEntityAsync(update);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result.Id);
        }
        [HttpGet]
        [Authorize(Policy = "order.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return Ok();
            }
            if (await _ticketOrderService.AnyAsync(x=>x.OrderId == id))
            {
                var ticket = _map.Map<TicketOrderListDto>(await _ticketOrderService.GetAsync(x => x.OrderId == id));
                await _ticketOrderService.DeleteByIdAsync(ticket.Id);
            }
            await _orderService.DeleteByIdAsync(id);
            return Ok(id);
        }
        [HttpGet]
        [Authorize(Policy = "order.getorderticketfile")]
        public async Task<IActionResult> GetOrderTicketFile(int ticketId)
        {
            var ticketOrderPath = _ticketService.FindByIdAsync(ticketId).Result.OrderPath;
            return Ok(ticketOrderPath);

        }        
        [HttpGet]
        [Authorize(Policy = "order.alldelete")]
        public async Task<IActionResult> AllDelete(List<int> Ids)
        {
            if (Ids.Count > 0)
            {
                foreach (var id in Ids)
                {
                    await _orderService.DeleteByIdAsync(id);
                }
                return Ok();
            }
            return Ok();

        }
    }
}
