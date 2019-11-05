using Core.Dtos;
using Core.Entities.CartEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        Task AddItemToCart(int customerId, AddItemToCartRequest request, CancellationToken cancellationToken);
        Task GetCustomer(int customerId, CancellationToken cancellationToken);
        Task<Cart> GetCart(int customerId);
    }
}
