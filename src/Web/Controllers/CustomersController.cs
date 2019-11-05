using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int customerId, CancellationToken cancellationToken)
        {
            await _customerService.GetCustomer(customerId, cancellationToken);
            return Ok();
        }

        [HttpPost]
        [Route("{customerId}/cart")]
        public async Task<IActionResult> AddToCart(int customerId, [FromBody] AddItemToCartRequest cartItem, CancellationToken cancellationToken)
        {
            await _customerService.AddItemToCart(customerId, cartItem, cancellationToken);
            return Ok();
        }

        [HttpGet("{id}/cart")]
        public async Task<IActionResult> GetCart(int customerId, CancellationToken cancellationToken)
        {
            var cart = _customerService.GetCart(customerId);
            return Ok(cart);
        }

        
    }
}
