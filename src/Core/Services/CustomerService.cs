using Core.Dtos;
using Core.Entities.CartEntity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IThingShopDbContext _dbContext;

        public CustomerService(IThingShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItemToCart(int customerId, AddItemToCartRequest request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers
                .Include(c => c.Cart)
                .SingleOrDefaultAsync(c => c.CustomerId == customerId);

            customer.Cart.AddCartItem(request.ProductId, request.Quantity, request.Price);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Cart> GetCart(int customerId) =>
            await _dbContext.Customers
                .Include(c => c.Cart)
                .Where(c => c.CustomerId == customerId)
                .Select(c => c.Cart)
                .SingleAsync();

        public async Task GetCustomer(int customerId, CancellationToken cancellationToken) => 
            await _dbContext.Customers.FindAsync(customerId, cancellationToken);
    }
}
