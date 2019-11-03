using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderService.GetByIdAsync(id, cancellationToken);
                return Ok(order);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderRequest orderRequest, CancellationToken cancellationToken)
        {
            try
            {
                await _orderService.CreateOrderAsync(orderRequest, cancellationToken);
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }


        //TODO: Might want to add Error handler action for middleware. 
    }
}