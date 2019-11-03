using Core.Dtos;
using Core.Entities.OrderEntity;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateOrderAsync(CreateOrderRequest orderRequest, CancellationToken cancellationToken);
    }
}