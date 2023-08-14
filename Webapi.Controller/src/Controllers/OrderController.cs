using Microsoft.AspNetCore.Authorization;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controller.src.Controllers
{
    //[Authorize]
    public class OrderController : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService baseService) : base(baseService)
        {
            _orderService = baseService;
        }

        [HttpPost]
        public override async Task<ActionResult<OrderReadDto>> CreateOne(OrderCreateDto orderCreateDto)
        {
            var orderReadDto = await _orderService.CreateOne(orderCreateDto);
            return CreatedAtAction(nameof(GetOneById), new { id = orderReadDto.User }, orderReadDto);
        }
    }
}