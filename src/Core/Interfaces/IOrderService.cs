using Core.Entities.OrderEntity;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Order GetOrder(int id);
    }
}