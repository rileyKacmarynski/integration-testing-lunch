using Core.Entities.OrderEntity;
using Core.Interfaces;
using System.Threading.Tasks;
using System;
using Core.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using Core.Entities.CartEntity;
using System.Collections.ObjectModel;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IThingShopDbContext _context;

        public OrderService(IThingShopDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) throw new ArgumentException($"Order {id} not found.");
            return order;
        }

        public async Task CreateOrderAsync(CreateOrderRequest orderRequest, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .Include(c => c.Cart)
                //.ThenInclude(c => c.Items)
                .SingleAsync(c => c.CustomerId == orderRequest.CustomerId, cancellationToken);

            var order = new Order(customer);
            order.AddItems(customer.Cart.Items);

            customer.EmptyCart();
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}